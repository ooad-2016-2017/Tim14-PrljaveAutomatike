using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorFinderApp.Models
{
    class Instruktor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstruktorId { get; set; }
        public double Ocjena { get; set; }
        public byte[] slika { get; set; }
        public List<Termin> PrijavljeniTermini { get; set; }
    }
}
