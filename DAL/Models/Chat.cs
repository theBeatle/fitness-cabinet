using System;
using System.Collections.Generic;

namespace Dal
{
    public partial class Chat
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        public virtual Receiver Receiver { get; set; }
        public virtual Sender Sender { get; set; }
    }
}
