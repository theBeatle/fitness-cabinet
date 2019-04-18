using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class Photo
    {
        public Photo()
        {
            People = new HashSet<Person>();
            Places = new HashSet<Place>();
        }

        public int Id { get; set; }
        public string Path { get; set; }

        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<Place> Places { get; set; }
    }
}
