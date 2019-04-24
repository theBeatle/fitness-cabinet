using System;
using System.Collections.Generic;

namespace Dal
{
    public partial class Receiver
    {
        public Receiver()
        {
            Chat = new HashSet<Chat>();
        }

        public int Id { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Chat> Chat { get; set; }
    }
}
