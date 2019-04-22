using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Models.DB
{
    public partial class Chat
    {
        public string Id { get; set; }
        public string ReceiverId { get; set; }
        public string SenderId { get; set; }

        public virtual Receiver Receiver { get; set; }
        public virtual Sender Sender { get; set; }
    }
}
