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
    public class StellenanzeigensController : Controller
    {
        private StellenanzeigeContext _context;

        public StellenanzeigensController(StellenanzeigeContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var stellenanzeigen = _context.Stellenanzeigen.Select(i => new {
                i.Id,
                i.Preis

            }) ;

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Preis" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(stellenanzeigen, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Stellenanzeigen();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Stellenanzeigen.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Preis });
        }

        [HttpPut]
        public async Task<IActionResult> Put(string key, string values) {
            var model = await _context.Stellenanzeigen.FirstOrDefaultAsync(item => item.Preis == key);
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
        public async Task Delete(string key) {
            var model = await _context.Stellenanzeigen.FirstOrDefaultAsync(item => item.Preis == key);

            _context.Stellenanzeigen.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(Stellenanzeigen model, IDictionary values)
        {
            string PREIS = nameof(Stellenanzeigen.Preis);

            if(values.Contains(PREIS)) {
                model.Preis = Convert.ToString(values[PREIS]);
            }
            string Id = nameof(Stellenanzeigen.Id);

            if (values.Contains(Id))
            {
                model.Id = Convert.ToInt32(values[Id]);
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