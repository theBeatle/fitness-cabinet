using System;
using System.Collections.Generic;

namespace Dal
{
    public partial class PersonsPhotos
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int PhotoId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Photos Photo { get; set; }
    }
}
