using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bewerber.Models
{
    public class BewerberModel
    {
       [Key] public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Erstellt { get; set; }

        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

        public string NL { get; set;  }
        public string Vorname { get; set; }

        public string Nachname { get; set; }

        public string PLZ { get; set; }

        public string Berufsgruppe { get; set; }

        public string Berufdetail { get; set; }

        public string Netzwerke { get; set; }

        public string Netzwerkdetail { get; set; }

        public string Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime Vorstellung { get; set; }

        public bool Erfolgt { get; set; }

        public bool Eingestellt { get; set; }

        public string RefMail { get; set; }

        public string Bearbeiter { get; set; }












    }
}
