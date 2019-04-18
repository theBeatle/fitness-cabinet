using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp
{
    public class Library
    {
        readonly IDal library = new Edal();

        public bool PersonSaveCredentials(string login, string password, string firstName, string lastName, string email, string sex, string phone, string isDeleted, string isBanned)
        {
            bool t = library.PersonSaveCredentials(login, password, firstName, lastName, email, sex, phone, isDeleted, isBanned);
            return t;
        }

        public ICollection<Person> GetAllPeople()
        {
            var t = library.GetAllPeople();
            return t;
        }

        public bool PersonLoadPhoto(string login, string password, string path)
        {
            var t = library.PersonLoadPhoto(login, password, path);
            return t;
        }

       
    }
}
