using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models.Coach
{
    public class CoachProduct
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string SportKind { get; set; }
        public string TrainingName { get; set; }
        public string PlaceName { get; set; }
        public string WorkShedule { get; set; }
        public bool IsSimplePlace { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string PlaceDescription { get; set; }
        public string Photo { get; set; }
    }
}
