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
    public class BewerberModelsneuController : Controller
    {
        private BewerberContext _context;

        public BewerberModelsneuController(BewerberContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var bewerbermodel = _context.uebersicht.Select(i => new {
                i.Id,
                i.Erstellt,
                i.Datum,
                i.NL,
                i.Vorname,
                i.Nachname,
                i.PLZ,
                i.Berufsgruppe,
                i.Berufdetail,
                i.Netzwerke,
                i.Netzwerkdetail,
                i.Status,
                i.Vorstellung,
                i.Erfolgt,
                i.Eingestellt,
                i.RefMail,
                i.Bearbeiter
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(bewerbermodel, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new BewerberModel();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.uebersicht.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.uebersicht.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.uebersicht.FirstOrDefaultAsync(item => item.Id == key);

            _context.uebersicht.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(BewerberModel model, IDictionary values) {
            string ID = nameof(BewerberModel.Id);
            string ERSTELLT = nameof(BewerberModel.Erstellt);
            string DATUM = nameof(BewerberModel.Datum);
            string NL = nameof(BewerberModel.NL);
            string VORNAME = nameof(BewerberModel.Vorname);
            string NACHNAME = nameof(BewerberModel.Nachname);
            string PLZ = nameof(BewerberModel.PLZ);
            string BERUFSGRUPPE = nameof(BewerberModel.Berufsgruppe);
            string BERUFDETAIL = nameof(BewerberModel.Berufdetail);
            string NETZWERKE = nameof(BewerberModel.Netzwerke);
            string NETZWERKDETAIL = nameof(BewerberModel.Netzwerkdetail);
            string STATUS = nameof(BewerberModel.Status);
            string VORSTELLUNG = nameof(BewerberModel.Vorstellung);
            string ERFOLGT = nameof(BewerberModel.Erfolgt);
            string EINGESTELLT = nameof(BewerberModel.Eingestellt);
            string REF_MAIL = nameof(BewerberModel.RefMail);
            string BEARBEITER = nameof(BewerberModel.Bearbeiter);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(ERSTELLT)) {
                model.Erstellt = Convert.ToDateTime(values[ERSTELLT]);
            }

            if(values.Contains(DATUM)) {
                model.Datum = Convert.ToDateTime(values[DATUM]);
            }

            if(values.Contains(NL)) {
                model.NL = Convert.ToString(values[NL]);
            }

            if(values.Contains(VORNAME)) {
                model.Vorname = Convert.ToString(values[VORNAME]);
            }

            if(values.Contains(NACHNAME)) {
                model.Nachname = Convert.ToString(values[NACHNAME]);
            }

            if(values.Contains(PLZ)) {
                model.PLZ = Convert.ToString(values[PLZ]);
            }

            if(values.Contains(BERUFSGRUPPE)) {
                model.Berufsgruppe = Convert.ToString(values[BERUFSGRUPPE]);
            }

            if(values.Contains(BERUFDETAIL)) {
                model.Berufdetail = Convert.ToString(values[BERUFDETAIL]);
            }

            if(values.Contains(NETZWERKE)) {
                model.Netzwerke = Convert.ToString(values[NETZWERKE]);
            }

            if(values.Contains(NETZWERKDETAIL)) {
                model.Netzwerkdetail = Convert.ToString(values[NETZWERKDETAIL]);
            }

            if(values.Contains(STATUS)) {
                model.Status = Convert.ToString(values[STATUS]);
            }

            if(values.Contains(VORSTELLUNG)) {
                model.Vorstellung = Convert.ToDateTime(values[VORSTELLUNG]);
            }

            if(values.Contains(ERFOLGT)) {
                model.Erfolgt = Convert.ToBoolean(values[ERFOLGT]);
            }

            if(values.Contains(EINGESTELLT)) {
                model.Eingestellt = Convert.ToBoolean(values[EINGESTELLT]);
            }

            if(values.Contains(REF_MAIL)) {
                model.RefMail = Convert.ToString(values[REF_MAIL]);
            }

            if(values.Contains(BEARBEITER)) {
                model.Bearbeiter = Convert.ToString(values[BEARBEITER]);
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