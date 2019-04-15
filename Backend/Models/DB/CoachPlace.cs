using System;
using System.Collections.Generic;

namespace Backend.Models.DB
{
    public partial class CoachPlace
    {
        public long Id { get; set; }
        public long CoachId { get; set; }
        public int PlaceId { get; set; }

        public virtual Coach Coach { get; set; }
        public virtual Place Place { get; set; }
    }
}
