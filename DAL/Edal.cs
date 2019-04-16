using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    class Edal : IDal
    {
        private readonly DbContext _ctx = new FitnessCabinetContext();

        public bool DBUserSaveCredentials(string login, string password, string firstName, string lastName, string email, string sex, string phone, string isDeleted, string isBanned)
        {
            var number = _ctx.Set<Person>().Count();

            if (!String.IsNullOrEmpty(fullName) && !String.IsNullOrEmpty(userName) && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password))
            {
                _ctx.DBUsers.Add(new Models.DBUser() { FullName = fullName, UserName = userName, Email = email, Password = password });
                _ctx.SaveChanges();

                return _ctx.DBUsers.Count() > number;
            }

            return false;
        }

        public bool IsUserNameInDb(string loginOrEmail)
        {
            throw new NotImplementedException();
        }

        public bool IsUserNameInDb(string loginOrEmail, string password)
        {
            throw new NotImplementedException();
        }
    }
}
