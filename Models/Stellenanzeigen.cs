using System;
using System.Collections.Generic;

#nullable disable

namespace Bewerber.Models
{
    public partial class Stellenanzeigen
    {
        public int Id { get; set; }
        public string Nl { get; set; }
        public string Bez { get; set; }
        public string Detail { get; set; }
        public DateTime? Vdatum { get; set; }
        public DateTime? Bdatum { get; set; }
        public string Preis { get; set; }
        public string Referenz { get; set; }
        public decimal? Gesamt { get; set; }
        public decimal? Eingestellt { get; set; }
        public decimal? Unbearbeitet { get; set; }
    }
}
