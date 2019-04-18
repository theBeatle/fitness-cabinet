using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class PersonPhoto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int PhotoId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Photo Photo { get; set; }
    }
}
