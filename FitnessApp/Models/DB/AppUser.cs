using Microsoft.AspNetCore.Identity;

namespace FitnessApp.Models.DB
{
    public class AppUser : IdentityUser
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}