using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class Person : IdentityUser
    {
        public Person()
        {
            Coach = new HashSet<Coach>();
            Photos = new HashSet<Photo>();
            Receiver = new HashSet<Receiver>();
            Sender = new HashSet<Sender>();
            Trainee = new HashSet<Trainee>();
        }
        
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsBanned { get; set; }

        public virtual SexStatus SexStatus { get; set; }
        public virtual ICollection<Coach> Coach { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Receiver> Receiver { get; set; }
        public virtual ICollection<Sender> Sender { get; set; }
        public virtual ICollection<Trainee> Trainee { get; set; }
    }
}
