using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Bewerber.Data;
using Bewerber.Models;

namespace Bewerber.Controllers
{
    [Route("api/[controller]/[action]")]
    public class StellenangebotesController : Controller
    {
        private StellenangeboteContext _context;

        public StellenangebotesController(StellenangeboteContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var stellenanzeigen = _context.Stellenanzeigen.Select(i => new {
                i.Id,
                i.NL,
                i.BEZ,
                i.Detail,
                i.VDatum,
                i.BDatum,
                i.Preis,
                i.Referenz,
                i.Gesamt,
                i.Eingestellt,
                i.Unbearbeitet
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(stellenanzeigen, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Stellenangebote();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Stellenanzeigen.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Stellenanzeigen.FirstOrDefaultAsync(item => item.Id == key);
            if(model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.Stellenanzeigen.FirstOrDefaultAsync(item => item.Id == key);

            _context.Stellenanzeigen.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(Stellenangebote model, IDictionary values) {
            string ID = nameof(Stellenangebote.Id);
            string NL = nameof(Stellenangebote.NL);
            string BEZ = nameof(Stellenangebote.BEZ);
            string DETAIL = nameof(Stellenangebote.Detail);
            string VDATUM = nameof(Stellenangebote.VDatum);
            string BDATUM = nameof(Stellenangebote.BDatum);
            string PREIS = nameof(Stellenangebote.Preis);
            string REFERENZ = nameof(Stellenangebote.Referenz);
            string GESAMT = nameof(Stellenangebote.Gesamt);
            string EINGESTELLT = nameof(Stellenangebote.Eingestellt);
            string UNBEARBEITET = nameof(Stellenangebote.Unbearbeitet);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(NL)) {
                model.NL = Convert.ToString(values[NL]);
            }

            if(values.Contains(BEZ)) {
                model.BEZ = Convert.ToString(values[BEZ]);
            }

            if(values.Contains(DETAIL)) {
                model.Detail = Convert.ToString(values[DETAIL]);
            }

            if(values.Contains(VDATUM)) {
                model.VDatum = Convert.ToDateTime(values[VDATUM]);
            }

            if(values.Contains(BDATUM)) {
                model.BDatum = Convert.ToDateTime(values[BDATUM]);
            }

            if(values.Contains(PREIS)) {
                model.Preis = Convert.ToString(values[PREIS]);
            }

            if(values.Contains(REFERENZ)) {
                model.Referenz = Convert.ToString(values[REFERENZ]);
            }

            if(values.Contains(GESAMT)) {
                model.Gesamt = Convert.ToDecimal(values[GESAMT]);
            }

            if(values.Contains(EINGESTELLT)) {
                model.Eingestellt = Convert.ToDecimal(values[EINGESTELLT]);
            }

            if(values.Contains(UNBEARBEITET)) {
                model.Unbearbeitet = Convert.ToDecimal(values[UNBEARBEITET]);
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}