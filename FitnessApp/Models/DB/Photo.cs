using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class Photo
    {
        public Photo()
        {
            Places = new HashSet<Place>();
            PersonPhotos = new HashSet<PersonPhoto>();
            PlacePhotos = new HashSet<PlacePhoto>();
        }

        public int Id { get; set; }
        public string Path { get; set; }
        
        public virtual ICollection<Place> Places { get; set; }
        public virtual ICollection<PersonPhoto> PersonPhotos { get; set; }
        public virtual ICollection<PlacePhoto> PlacePhotos { get; set; }
    }
}
