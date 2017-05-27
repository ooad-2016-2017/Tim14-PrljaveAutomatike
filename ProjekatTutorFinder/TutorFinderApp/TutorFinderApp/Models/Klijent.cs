using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TutorFinderApp.Models
{
    class Klijent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KlijentId { get; set; }
        public List<Termin> PrijavljeniTermini { get; set; }
    }
}
