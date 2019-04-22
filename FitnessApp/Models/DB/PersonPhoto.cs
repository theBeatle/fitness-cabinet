using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class PersonPhoto
    {
        public string Id { get; set; }
        public string PersonId { get; set; }
        public string PhotoId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Photo Photo { get; set; }
    }
}
