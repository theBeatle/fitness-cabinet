using System;
using System.Collections.Generic;

namespace Dal
{
    public partial class Place
    {
        public Place()
        {
            CoachPlace = new HashSet<CoachPlace>();
            PlacesPhotos = new HashSet<PlacesPhotos>();
            RealService = new HashSet<RealService>();
            Usabilities = new HashSet<Usabilities>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Track { get; set; }
        public long? AddressId { get; set; }
        public bool IsSimplePlace { get; set; }
        public string WorkShedule { get; set; }
        public int Rating { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<CoachPlace> CoachPlace { get; set; }
        public virtual ICollection<PlacesPhotos> PlacesPhotos { get; set; }
        public virtual ICollection<RealService> RealService { get; set; }
        public virtual ICollection<Usabilities> Usabilities { get; set; }
    }
}
