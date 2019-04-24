using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class Coach
    {
        public Coach()
        {
            CoachPlaces = new HashSet<CoachPlace>();
            RealService = new HashSet<RealService>();
            Speciality = new HashSet<Speciality>();
        }

        public string Id { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string WorkShedule { get; set; }
        public string PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<CoachPlace> CoachPlaces { get; set; }
        public virtual ICollection<RealService> RealService { get; set; }
        public virtual ICollection<Speciality> Speciality { get; set; }
    }
}
