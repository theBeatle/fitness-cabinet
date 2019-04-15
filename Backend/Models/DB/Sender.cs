using System;
using System.Collections.Generic;

namespace Backend.Models.DB
{
    public partial class Sender
    {
        public Sender()
        {
            Chat = new HashSet<Chat>();
        }

        public long Id { get; set; }
        public long PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Chat> Chat { get; set; }
    }
}
