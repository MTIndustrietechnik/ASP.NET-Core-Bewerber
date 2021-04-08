using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bewerber.Models
{
    public class BewerberModelV2
    {
        [Key]
        public int BEW_ID { get; set; }
        public int? BEW_NR { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BEW_DATUM { get; set; }
        public string BEW_NL { get; set; }
        public string BEW_VNAME { get; set; }
        public string BEW_NNAME { get; set; }
        public string BEW_BERUF { get; set; }
        public int BEW_BGRUPPE { get; set; }
        public string BEW_NETZWERK { get; set; }
        [DefaultValue(true)]
        public int? BEW_MKTDATID { get; set; }
        public int? BEW_MKTPRSID { get; set; }
        public string BEW_STATUS { get; set; }
        public int? BEW_STADAT { get; set;  }
        public string BEW_NETZWERK2 { get; set; }
        public string BEW_ANMERKUNG { get; set; }
        public string BEW_BEARBEITER { get; set; }
        [DataType(DataType.Date)]
        public DateTime? VOR_DATUM { get; set; }
        public bool VOR_OFFEN { get; set; }
        public bool VOR_ERFOL { get; set; }
        public bool VOR_ABGES { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EIN_DATUM { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EIN_AUSDAT { get; set; }
        public bool EIN_OFFEN { get; set; }
        public bool EIN_ERFOL { get; set; }
        public bool EIN_AUSGE { get; set; }
        public int? BEW_PSNR { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BEW_CREATE { get; set; }
        public string BEW_PLZ { get; set; }
        public string BEW_ORT { get; set; }
        public string BEW_REFMAIL { get; set; }
        public int? REFMAIL { get; set; }
        public string BEW_REFNR { get; set; }
        public int? REFNR { get; set; }
        public int? BEW_ANGES { get; set; }
        public int? MAIL_ID { get; set; }
        public int? MAILANH_ID { get; set; }
        public string BEW_MAIL { get; set; }

        public int? AUSW_ID{ get; set; }
        public int? BEW_NLNR { get; set; }













    }
}
