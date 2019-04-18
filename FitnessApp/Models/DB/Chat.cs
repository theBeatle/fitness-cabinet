using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class Chat
    {
        public int Id { get; set; }

        public virtual Receiver Receiver { get; set; }
        public virtual Sender Sender { get; set; }
    }
}
