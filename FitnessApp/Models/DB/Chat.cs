using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Models.DB
{
    public partial class Chat
    {
        public int Id { get; set; }
        public int ReceiverId { get; set; }
        public int SenderId { get; set; }

        public virtual Receiver Receiver { get; set; }
        public virtual Sender Sender { get; set; }
    }
}
