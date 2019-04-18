using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class Coach
    {
        public Coach()
        {
            CoachPlace = new HashSet<CoachPlace>();
            RealService = new HashSet<RealService>();
            Speciality = new HashSet<Speciality>();
        }

        public int Id { get; set; }
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
