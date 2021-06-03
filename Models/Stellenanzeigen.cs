using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Bewerber.Models
{
    public partial class Stellenanzeigen
    {
        [Key] public int Id { get; set; } 
       public string Preis { get; set; }

    }
}
