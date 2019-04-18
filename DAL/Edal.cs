using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;


namespace Dal
{
    public static class Temp
    {
        public static bool ToBoolean(this string input)
        {
            //Account for a string that does not need to be processed
            if (string.IsNullOrEmpty(input))
                return false;

            return (input.Trim().ToLower() == "true") || (input.Trim() == "1");
        }
    }



    public class Edal : IDal
    {
        private readonly DbContext _ctx = new FitnessCabinetContext();       

        public bool IsPersonEmailInDb(string loginOrEmail)
        {
            throw new NotImplementedException();
        }

        public bool IsPersonInDb(string loginOrEmail, string password)
        {
            throw new NotImplementedException();
        }


        public bool PersonSaveCredentials(string login, string password, string firstName, string lastName, string email, string sex, string phone, string isDeleted, string isBanned)
        {
            var number = _ctx.Set<Person>().Count();
            var isdeleted = isDeleted.ToBoolean();/*isDeleted == "true";*/
            var isbanned = isBanned.ToBoolean();/*isBanned == "true";*/


            if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password) && !String.IsNullOrEmpty(firstName) && !String.IsNullOrEmpty(lastName)
                && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(sex) && !String.IsNullOrEmpty(isDeleted) && !String.IsNullOrEmpty(isBanned))
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
                var number2 = _ctx.Set<Person>().Count();
                return number2 > number;
            }

            return false;
        }


        public ICollection<Person> GetAllPeople()
        {           
            return _ctx.Set<Person>().ToList();           
        }

        public bool PersonLoadPhoto(string login, string password, string path)
        {
            var person = _ctx.Set<Person>().FirstOrDefault(p => p.Login == login && p.Password == password);

            if (person != null)
            {
                //var number = _ctx.Set<PersonsPhotos>().Count();
                //_ctx.Set<PersonsPhotos>().Add( new PersonsPhotos() { Person = person, Photo = new Photos { Path = path} });
                //var number2 = _ctx.Set<PersonsPhotos>().Count();

                //var number = _ctx.Set<Photos>().Count();
                //_ctx.Set<Photos>().Add(new Photos() { Path = path });
                //var number2 = _ctx.Set<Photos>().Count();


                return true;
            }
            return false;
        }
    }
}
