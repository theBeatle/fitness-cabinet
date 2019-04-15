using System;
using System.Collections.Generic;

namespace Backend.Models.DB
{
    public partial class Usabilities
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public string UsabilityName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public virtual Place Place { get; set; }
    }
}
