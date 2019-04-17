using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class Edal : IDal
    {
        private readonly DbContext _ctx = new FitnessCabinetContext();

        public bool PersonSaveCredentials(string login, string password, string firstName, string lastName, string email, string sexStatusId, string phone, string isDeleted, string isBanned)
        {
            var number = _ctx.Set<Person>().Count();
            var isdeleted = isDeleted =="true";
            var isbanned = isBanned=="true";
            var sexstatusid = Int32.Parse(sexStatusId);

            if (!String.IsNullOrEmpty(firstName) && !String.IsNullOrEmpty(lastName) && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password))
            {
                _ctx.Set<Person>().Add(new Person() { Login = login, Password = password, FirstName = firstName, LastName = lastName,  Email = email,  SexStatusId= sexstatusid, Phone =phone, IsDeleted= isdeleted, IsBanned = isbanned });
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

        //public static bool ToBoolean(this string input)
        //{
        //    //Account for a string that does not need to be processed
        //    if (string.IsNullOrEmpty(input))
        //        return false;

        //    return (input.Trim().ToLower() == "true") || (input.Trim() == "1");
        //}

        //public bool DBUserSaveCredentials(string login, string password, string firstName, string lastName, string email, string sex, string phone, string isDeleted, string isBanned)
        //{
        //    var number = _ctx.Set<Person>().Count();
        //    var isdeleted = isDeleted == "true";
        //    var isbanned = isBanned == "true";
        //    var sexstatusid = 1;

        //    if (!String.IsNullOrEmpty(firstName) && !String.IsNullOrEmpty(lastName) && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password))
        //    {
        //        _ctx.Set<Person>().Add(new Person() { SexStatus = new SexStatus { Sex = "male" }, Login = login, Password = password, FirstName = firstName, LastName = lastName, Email = email, Phone = phone, IsDeleted = isdeleted, IsBanned = isbanned });
        //        _ctx.SaveChanges();

        //        return _ctx.Set<Person>().Count() > number;
        //    }

        //    return false;
        //}

        public bool DBUserSaveCredentials(string login, string password, string firstName, string lastName, string email, string sex, string phone, string isDeleted, string isBanned)
        {
            var number = _ctx.Set<Person>().Count();
            var isdeleted = isDeleted == "true";
            var isbanned = isBanned == "true";


            if (!String.IsNullOrEmpty(firstName) && !String.IsNullOrEmpty(lastName) && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password))
            {
                //if (_ctx.Set<SexStatus>().Count() == 0)
                //{
                //    _ctx.Set<SexStatus>().Add(new SexStatus { Sex = "male"  });
                //    _ctx.Set<SexStatus>().Add(new SexStatus { Sex = "female" });
                //    var t1 = _ctx.Set<SexStatus>().Count();
                //}

                //var t = _ctx.Set<SexStatus>().Count();

                //var sexstatus = _ctx.Set<SexStatus>().First(s => s.Sex == "male");

                _ctx.Set<Person>().Add(new Person() { SexStatus = new SexStatus { Sex = sex }, Login = login, Password = password, FirstName = firstName, LastName = lastName, Email = email, Phone = phone, IsDeleted = isdeleted, IsBanned = isbanned });
                _ctx.SaveChanges();

                return _ctx.Set<Person>().Count() > number;
            }

            return false;
        }
    }
}
