using System;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class Sender
    {
        public Sender()
        {
            Chat = new HashSet<Chat>();
        }

        public string Id { get; set; }
        public string PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Chat> Chat { get; set; }
    }
}
