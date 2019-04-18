using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class Speciality
    {
        public int Id { get; set; }
        public string Specialities { get; set; }
        public string Experience { get; set; }
        public int Rating { get; set; }

        public virtual Coach Coach { get; set; }
    }
}
