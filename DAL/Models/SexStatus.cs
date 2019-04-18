using System;
using System.Collections.Generic;

namespace Dal
{
    public partial class SexStatus
    {
        public SexStatus()
        {
            Person = new HashSet<Person>();
        }

        public long Id { get; set; }
        public string Sex { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
