using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.ViewModels
{
    public class PersonDTO
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long SexStatusId { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsBanned { get; set; }
    }
}
