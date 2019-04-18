using System;
using System.Collections.Generic;

namespace Dal
{
    public partial class Chat
    {
        public long Id { get; set; }
        public long SenderId { get; set; }
        public long ReceiverId { get; set; }

        public virtual Receiver Receiver { get; set; }
        public virtual Sender Sender { get; set; }
    }
}
