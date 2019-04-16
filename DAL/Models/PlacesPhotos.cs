using System;
using System.Collections.Generic;

namespace Dal
{
    public partial class PlacesPhotos
    {
        public long Id { get; set; }
        public int PlaceId { get; set; }
        public long PhotoId { get; set; }

        public virtual Photos Photo { get; set; }
        public virtual Place Place { get; set; }
    }
}
