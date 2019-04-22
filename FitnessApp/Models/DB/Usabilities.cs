using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class Usabilities
    {
        public string Id { get; set; }
        public string UsabilityName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string PlaceId { get; set; }

        public virtual Place Place { get; set; }
    }
}
