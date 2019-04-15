using System;
using System.Collections.Generic;

namespace Backend.Models.DB
{
    public partial class PersonsPhotos
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public long PhotoId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Photos Photo { get; set; }
    }
}
