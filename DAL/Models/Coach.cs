using System;
using System.Collections.Generic;

namespace Dal
{
    public partial class Coach
    {
        public Coach()
        {
            CoachPlace = new HashSet<CoachPlace>();
            RealService = new HashSet<RealService>();
            Speciality = new HashSet<Speciality>();
        }

        public long Id { get; set; }
        public long PersonId { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string WorkShedule { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<CoachPlace> CoachPlace { get; set; }
        public virtual ICollection<RealService> RealService { get; set; }
        public virtual ICollection<Speciality> Speciality { get; set; }
    }
}
