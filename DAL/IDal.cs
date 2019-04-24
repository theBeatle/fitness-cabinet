using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;


namespace Dal
{
    public interface IDal
    {
        bool PersonSaveCredentials(string login, string password, string firstName, string lastName, string email, string sex, string phone, string isDeleted, string isBanned);
        bool IsPersonEmailInDb(string loginOrEmail);
        bool IsPersonInDb(string loginOrEmail, string password);

        ICollection<Person> GetAllPeople();

        bool PersonLoadPhoto(string login, string password,string path);

        Person GetPersonById(string id);
        void UpdatePerson(Person person);
        bool RemovePerson(Person person);
        bool AddPerson(Person person);
    }
}
