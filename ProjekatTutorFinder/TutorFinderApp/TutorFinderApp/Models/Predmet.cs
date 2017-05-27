using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TutorFinderApp.Models
{
    class Predmet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PredmetId { get; set; }
        public string ImePredmeta { get; set; }
    }
}
