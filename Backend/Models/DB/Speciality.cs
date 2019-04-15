using System;
using System.Collections.Generic;

namespace Backend.Models.DB
{
    public partial class Speciality
    {
        public long Id { get; set; }
        public long CoachId { get; set; }
        public string Speciality1 { get; set; }
        public string Experience { get; set; }
        public int Rating { get; set; }

        public virtual Coach Coach { get; set; }
    }
}
