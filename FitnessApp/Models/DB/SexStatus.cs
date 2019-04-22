using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class SexStatus
    {
        public SexStatus()
        {
            Person = new HashSet<Person>();
        }

        public string Id { get; set; }
        public string Sex { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
