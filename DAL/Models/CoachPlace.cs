using System;
using System.Collections.Generic;

namespace Dal
{
    public partial class CoachPlace
    {
        public int Id { get; set; }
        public int CoachId { get; set; }
        public int PlaceId { get; set; }

        public virtual Coach Coach { get; set; }
        public virtual Place Place { get; set; }
    }
}
