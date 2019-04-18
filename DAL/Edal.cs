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

        public bool PersonSaveCredentials(string login, string password, string firstName, string lastName, string email, string sexStatusId, string phone, string isDeleted, string isBanned)
        {
            var number = _ctx.Set<Person>().Count();
            var isdeleted = ToBoolean(isDeleted);
            var isbanned = ToBoolean(isBanned);

            if (!String.IsNullOrEmpty(fullName) && !String.IsNullOrEmpty(userName) && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password))
            {
                _ctx.Set<Person>().Add(new Person() { Login = login, Password = password, FirstName = firstName, LastName = lastName,  Email = email,  SexStatusId=sexStatusId, Phone =phone, IsDeleted= isdeleted, IsBanned = isbanned });
                _ctx.SaveChanges();

                return _ctx.Set<Person>().Count() > number;
            }

            return false;
        }

        public bool IsPersonEmailInDb(string loginOrEmail)
        {
            throw new NotImplementedException();
        }

        public bool IsPersonInDb(string loginOrEmail, string password)
        {
            throw new NotImplementedException();
        }

        public static bool ToBoolean(this string input)
        {
            //Account for a string that does not need to be processed
            if (string.IsNullOrEmpty(input))
                return false;

            return (input.Trim().ToLower() == "true") || (input.Trim() == "1");
        }
    }
}
