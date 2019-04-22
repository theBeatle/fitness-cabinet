using System;
using System.Collections.Generic;

namespace Dal
{
    public partial class Person
    {
        public Person()
        {
            Coach = new HashSet<Coach>();
            PersonsPhotos = new HashSet<PersonsPhotos>();
            Receiver = new HashSet<Receiver>();
            Sender = new HashSet<Sender>();
            Trainee = new HashSet<Trainee>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int SexStatusId { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsBanned { get; set; }

        public virtual SexStatus SexStatus { get; set; }
        public virtual ICollection<Coach> Coach { get; set; }
        public virtual ICollection<PersonsPhotos> PersonsPhotos { get; set; }
        public virtual ICollection<Receiver> Receiver { get; set; }
        public virtual ICollection<Sender> Sender { get; set; }
        public virtual ICollection<Trainee> Trainee { get; set; }
    }
}
