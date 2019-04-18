using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class Address
    {
        public Address()
        {
            Place = new HashSet<Place>();
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string intitude { get; set; }
        public string Latitude { get; set; }

        public virtual ICollection<Place> Place { get; set; }
    }
}
