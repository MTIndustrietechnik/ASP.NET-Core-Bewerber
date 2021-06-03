using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bewerber.Models
{
    public class Stellenangebote
    {
        
        [Key] public int Id { get; set; }

        public string NL { get; set; }
        public string BEZ { get; set; }
        public string Detail { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DataType(DataType.Date)]
        public DateTime VDatum { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DataType(DataType.Date)]
        public DateTime BDatum { get; set; }
        public string Preis { get; set; }
        public string Referenz { get; set; }
        public decimal Gesamt { get; set; }

        public decimal Eingestellt { get; set; }
        public decimal Unbearbeitet { get; set; }
    }

}
