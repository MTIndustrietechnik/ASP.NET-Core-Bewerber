using System;
using System.Collections.Generic;

#nullable disable

namespace Bewerber.Models
{
    public partial class Uebersicht
    {
        public int Id { get; set; }
        public DateTime? Erstellt { get; set; }
        public DateTime? Datum { get; set; }
        public string Nl { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Plz { get; set; }
        public string Berufsgruppe { get; set; }
        public string Berufdetail { get; set; }
        public string Netzwerke { get; set; }
        public string Netzwerkdetail { get; set; }
        public string Status { get; set; }
        public DateTime? Vorstellung { get; set; }
        public bool? Erfolgt { get; set; }
        public bool? Eingestellt { get; set; }
        public string RefMail { get; set; }
        public string Bearbeiter { get; set; }
    }
}
