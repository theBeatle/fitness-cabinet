using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class Place
    {
        public Place()
        {
            CoachPlaces = new HashSet<CoachPlace>();
            RealService = new HashSet<RealService>();
            PlacePhotos = new HashSet<PlacePhoto>();
            Usabilities = new HashSet<Usabilities>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Track { get; set; }
        public bool IsSimplePlace { get; set; }
        public string WorkShedule { get; set; }
        public int Rating { get; set; }
        public string AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<CoachPlace> CoachPlaces { get; set; }
        public virtual ICollection<RealService> RealService { get; set; }
        public virtual ICollection<PlacePhoto> PlacePhotos { get; set; }
        public virtual ICollection<Usabilities> Usabilities { get; set; }
    }
}
