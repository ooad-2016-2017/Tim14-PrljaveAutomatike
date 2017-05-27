using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TutorFinderApp.Models
{
    class Termin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TerminId { get; set; }
        [Required]
        public Predmet Predmet { get; set; }
        [Required]
        public DateTime VrijemeOdrzavanja { get; set; }
        [Required]
        public byte[] QrKod { get; set; }
    }
}
