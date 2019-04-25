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
        public string City { get; set; }
        public string SportKind { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
    }
}
