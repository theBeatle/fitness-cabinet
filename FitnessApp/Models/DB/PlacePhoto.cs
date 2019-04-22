using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class PlacePhoto
    {
        public string Id { get; set; }
        public string PlaceId { get; set; }
        public string PhotoId { get; set; }

        public virtual Photo Photo { get; set; }
        public virtual Place Place { get; set; }
    }
}
