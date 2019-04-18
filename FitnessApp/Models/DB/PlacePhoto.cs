using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class PlacePhoto
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public int PhotoId { get; set; }

        public virtual Photo Photo { get; set; }
        public virtual Place Place { get; set; }
    }
}
