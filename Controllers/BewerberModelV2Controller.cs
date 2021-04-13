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
    public class BewerberModelV2Controller : Controller
    {
        private BewerberContextV2 _context;

        public BewerberModelV2Controller(BewerberContextV2 context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var bewerber = _context.BEWERBER.Select(i => new {
                i.BEW_ID,
                i.BEW_NR,
                i.BEW_DATUM,
                i.BEW_NL,
                i.BEW_VNAME,
                i.BEW_NNAME,
                i.BEW_BERUF,
                i.BEW_BGRUPPE,
                i.BEW_NETZWERK,
                i.BEW_MKTDATID,
                i.BEW_MKTPRSID,
                i.BEW_STATUS,
                i.BEW_STADAT,
                i.BEW_NETZWERK2,
                i.BEW_ANMERKUNG,
                i.BEW_BEARBEITER,
                i.VOR_DATUM,
                i.VOR_OFFEN,
                i.VOR_ERFOL,
                i.VOR_ABGES,
                i.EIN_DATUM,
                i.EIN_AUSDAT,
                i.EIN_OFFEN,
                i.EIN_ERFOL,
                i.EIN_AUSGE,
                i.BEW_PSNR,
                i.BEW_CREATE,
                i.BEW_PLZ,
                i.BEW_ORT,
                i.BEW_REFMAIL,
                i.REFMAIL,
                i.BEW_REFNR,
                i.REFNR,
                i.BEW_ANGES,
                i.MAIL_ID,
                i.MAILANH_ID,
                i.BEW_MAIL,
                i.AUSW_ID,
                i.BEW_NLNR,
                i.Notizen,
                i.BEW_TELEFON
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "BEW_ID" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(bewerber, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new BewerberModelV2();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.BEWERBER.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.BEW_ID });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.BEWERBER.FirstOrDefaultAsync(item => item.BEW_ID == key);
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
            var model = await _context.BEWERBER.FirstOrDefaultAsync(item => item.BEW_ID == key);

            _context.BEWERBER.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(BewerberModelV2 model, IDictionary values) {
            string BEW_ID = nameof(BewerberModelV2.BEW_ID);
            string BEW_NR = nameof(BewerberModelV2.BEW_NR);
            string BEW_DATUM = nameof(BewerberModelV2.BEW_DATUM);
            string BEW_NL = nameof(BewerberModelV2.BEW_NL);
            string BEW_VNAME = nameof(BewerberModelV2.BEW_VNAME);
            string BEW_NNAME = nameof(BewerberModelV2.BEW_NNAME);
            string BEW_BERUF = nameof(BewerberModelV2.BEW_BERUF);
            string BEW_BGRUPPE = nameof(BewerberModelV2.BEW_BGRUPPE);
            string BEW_NETZWERK = nameof(BewerberModelV2.BEW_NETZWERK);
            string BEW_MKTDATID = nameof(BewerberModelV2.BEW_MKTDATID);
            string BEW_MKTPRSID = nameof(BewerberModelV2.BEW_MKTPRSID);
            string BEW_SATUS = nameof(BewerberModelV2.BEW_STATUS);
            string BEW_STADAT = nameof(BewerberModelV2.BEW_STADAT);
            string BEW_NETZWERK2 = nameof(BewerberModelV2.BEW_NETZWERK2);
            string BEW_ANMERKUNGEN = nameof(BewerberModelV2.BEW_ANMERKUNG);
            string BEW_BEARBEITER = nameof(BewerberModelV2.BEW_BEARBEITER);
            string VOR_DATUM = nameof(BewerberModelV2.VOR_DATUM);
            string VOR_OFFEN = nameof(BewerberModelV2.VOR_OFFEN);
            string VOR_ERFOL = nameof(BewerberModelV2.VOR_ERFOL);
            string VOR_ABGES = nameof(BewerberModelV2.VOR_ABGES);
            string EIN_DATUM = nameof(BewerberModelV2.EIN_DATUM);
            string EIN_AUSDAT = nameof(BewerberModelV2.EIN_AUSDAT);
            string EIN_OFFEN = nameof(BewerberModelV2.EIN_OFFEN);
            string EIN_ERFOL = nameof(BewerberModelV2.EIN_ERFOL);
            string EIN_AUSGE = nameof(BewerberModelV2.EIN_AUSGE);
            string BEW_PSNR = nameof(BewerberModelV2.BEW_PSNR);
            string BEW_CREATE = nameof(BewerberModelV2.BEW_CREATE);
            string BEW_PLZ = nameof(BewerberModelV2.BEW_PLZ);
            string BEW_ORT = nameof(BewerberModelV2.BEW_ORT);
            string BEW_REFMAIL = nameof(BewerberModelV2.BEW_REFMAIL);
            string REFMAIL = nameof(BewerberModelV2.REFMAIL);
            string BEW_REFNR = nameof(BewerberModelV2.BEW_REFNR);
            string REFNR = nameof(BewerberModelV2.REFNR);
            string BEW_ANGES = nameof(BewerberModelV2.BEW_ANGES);
            string MAIL_ID = nameof(BewerberModelV2.MAIL_ID);
            string MAILANH_ID = nameof(BewerberModelV2.MAILANH_ID);
            string BEW_MAIL = nameof(BewerberModelV2.BEW_MAIL);

            string AUSW_ID = nameof(BewerberModelV2.AUSW_ID);
            string BEW_NLNR = nameof(BewerberModelV2.BEW_NLNR);
            string Notizen = nameof(BewerberModelV2.Notizen);
            string BEW_TELEFON = nameof(BewerberModelV2.BEW_TELEFON);

            if(values.Contains(BEW_ID)) {
                model.BEW_ID = Convert.ToInt32(values[BEW_ID]);
            }

            if(values.Contains(BEW_NR)) {
                model.BEW_NR = Convert.ToInt32(values[BEW_NR]);
            }

            if(values.Contains(BEW_DATUM)) {
                model.BEW_DATUM = Convert.ToDateTime(values[BEW_DATUM]);
            }

            if(values.Contains(BEW_NL)) {
                model.BEW_NL = Convert.ToString(values[BEW_NL]);
            }

            if(values.Contains(BEW_VNAME)) {
                model.BEW_VNAME = Convert.ToString(values[BEW_VNAME]);
            }

            if(values.Contains(BEW_NNAME)) {
                model.BEW_NNAME = Convert.ToString(values[BEW_NNAME]);
            }

            if(values.Contains(BEW_BERUF)) {
                model.BEW_BERUF = Convert.ToString(values[BEW_BERUF]);
            }

            if(values.Contains(BEW_BGRUPPE)) {
                model.BEW_BGRUPPE = Convert.ToInt32(values[BEW_BGRUPPE]);
            }

            if(values.Contains(BEW_NETZWERK)) {
                model.BEW_NETZWERK = Convert.ToString(values[BEW_NETZWERK]);
            }

            if(values.Contains(BEW_MKTDATID)) {
                model.BEW_MKTDATID = Convert.ToInt32(values[BEW_MKTDATID]);
            }

            if(values.Contains(BEW_MKTPRSID)) {
                model.BEW_MKTPRSID = Convert.ToInt32(values[BEW_MKTPRSID]);
            }

            if(values.Contains(BEW_SATUS)) {
                model.BEW_STATUS = Convert.ToString(values[BEW_SATUS]);
            }

            if(values.Contains(BEW_STADAT)) {
                model.BEW_STADAT = Convert.ToInt32(values[BEW_STADAT]);
            }

            if(values.Contains(BEW_NETZWERK2)) {
                model.BEW_NETZWERK2 = Convert.ToString(values[BEW_NETZWERK2]);
            }

            if(values.Contains(BEW_ANMERKUNGEN)) {
                model.BEW_ANMERKUNG = Convert.ToString(values[BEW_ANMERKUNGEN]);
            }

            if(values.Contains(BEW_BEARBEITER)) {
                model.BEW_BEARBEITER = Convert.ToString(values[BEW_BEARBEITER]);
            }

            if(values.Contains(VOR_DATUM)) {
                model.VOR_DATUM = Convert.ToDateTime(values[VOR_DATUM]);
            }

            if(values.Contains(VOR_OFFEN)) {
                model.VOR_OFFEN = Convert.ToBoolean(values[VOR_OFFEN]);
            }

            if(values.Contains(VOR_ERFOL)) {
                model.VOR_ERFOL = Convert.ToBoolean(values[VOR_ERFOL]);
            }

            if(values.Contains(VOR_ABGES)) {
                model.VOR_ABGES = Convert.ToBoolean(values[VOR_ABGES]);
            }

            if(values.Contains(EIN_DATUM)) {
                model.EIN_DATUM = Convert.ToDateTime(values[EIN_DATUM]);
            }

            if(values.Contains(EIN_AUSDAT)) {
                model.EIN_AUSDAT = Convert.ToDateTime(values[EIN_AUSDAT]);
            }

            if(values.Contains(EIN_OFFEN)) {
                model.EIN_OFFEN = Convert.ToBoolean(values[EIN_OFFEN]);
            }

            if(values.Contains(EIN_ERFOL)) {
                model.EIN_ERFOL = Convert.ToBoolean(values[EIN_ERFOL]);
            }

            if(values.Contains(EIN_AUSGE)) {
                model.EIN_AUSGE = Convert.ToBoolean(values[EIN_AUSGE]);
            }

            if (values.Contains(BEW_PSNR))
            {
                model.BEW_PSNR = Convert.ToInt32(values[BEW_PSNR]);
            }


            if(values.Contains(BEW_CREATE)) {
                model.BEW_CREATE = Convert.ToDateTime(values[BEW_CREATE]);
            }

            if(values.Contains(BEW_PLZ)) {
                model.BEW_PLZ = Convert.ToString(values[BEW_PLZ]);
            }

            if(values.Contains(BEW_ORT)) {
                model.BEW_ORT = Convert.ToString(values[BEW_ORT]);
            }

            if(values.Contains(BEW_REFMAIL)) {
                model.BEW_REFMAIL = Convert.ToString(values[BEW_REFMAIL]);
            }

            if(values.Contains(REFMAIL)) {
                model.REFMAIL = Convert.ToInt32(values[REFMAIL]);
            }

            if(values.Contains(BEW_REFNR)) {
                model.BEW_REFNR = Convert.ToString(values[BEW_REFNR]);
            }

            if(values.Contains(REFNR)) {
                model.REFNR = Convert.ToInt32(values[REFNR]);
            }

            if(values.Contains(BEW_ANGES)) {
                model.BEW_ANGES = Convert.ToInt32(values[BEW_ANGES]);
            }

            if(values.Contains(MAIL_ID)) {
                model.MAIL_ID = Convert.ToInt32(values[MAIL_ID]);
            }

            if(values.Contains(MAILANH_ID)) {
                model.MAILANH_ID = Convert.ToInt32(values[MAILANH_ID]);
            }

            if(values.Contains(BEW_MAIL)) {
                model.BEW_MAIL = Convert.ToString(values[BEW_MAIL]);
            }

            if(values.Contains(AUSW_ID)) {
                model.AUSW_ID = Convert.ToInt32(values[AUSW_ID]);
            }

            if(values.Contains(BEW_NLNR)) {
                model.BEW_NLNR = Convert.ToInt32(values[BEW_NLNR]);
            }

            if (values.Contains(Notizen))
            {
                model.Notizen = Convert.ToString(values[Notizen]);
            }

            if (values.Contains(BEW_TELEFON))
            {
                model.BEW_TELEFON = Convert.ToString(values[BEW_TELEFON]);
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