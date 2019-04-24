using System;
using System.Collections.Generic;

namespace Dal
{
    public partial class Photos
    {
        public Photos()
        {
            PersonsPhotos = new HashSet<PersonsPhotos>();
            PlacesPhotos = new HashSet<PlacesPhotos>();
        }

        public int Id { get; set; }
        public string Path { get; set; }

        public virtual ICollection<PersonsPhotos> PersonsPhotos { get; set; }
        public virtual ICollection<PlacesPhotos> PlacesPhotos { get; set; }
    }
}
