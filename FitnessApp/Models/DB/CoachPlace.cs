using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class CoachPlace
    {
        public string Id { get; set; }
        public string CoachId { get; set; }
        public string PlaceId { get; set; }

        public virtual Coach Coach { get; set; }
        public virtual Place Place { get; set; }

    }
}
