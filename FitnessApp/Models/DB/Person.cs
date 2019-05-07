using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FitnessApp.Models.DB
{
    public partial class Person : IdentityUser
    {
        public Person()
        {
            Coach = new HashSet<Coach>();
            Receiver = new HashSet<Receiver>();
            Sender = new HashSet<Sender>();
            PersonPhotos = new HashSet<PersonPhoto>();
            Trainee = new HashSet<Trainee>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? FacebookId { get; set; }
        public string PictureUrl { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsBanned { get; set; }
        public string SexStatusId { get; set; }

        public virtual SexStatus SexStatus { get; set; }
        public virtual ICollection<Coach> Coach { get; set; }
        public virtual ICollection<Receiver> Receiver { get; set; }
        public virtual ICollection<Sender> Sender { get; set; }
        public virtual ICollection<Trainee> Trainee { get; set; }
        public virtual ICollection<PersonPhoto> PersonPhotos { get; set; }
    }
}
