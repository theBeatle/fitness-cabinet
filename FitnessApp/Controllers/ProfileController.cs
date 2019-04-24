using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dal;
using System.IO;
using System.Net.Http.Headers;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        readonly IDal db = new Edal();

        // GET: api/Workers
        /// <summary>
        /// Read all workers information
        /// </summary>
        /// <returns>Collection of Workers</returns>
        [HttpGet]
        public ICollection<Person> GetPeople()
        {
            return db.GetAllPeople();
        }


        [HttpGet("{id}")]
        public Person GetPerson(string id)
        {
            var person = db.GetPersonById(id);

            //if (person == null)
            //{
            //    return NotFound();
            //}

            return person;
        }

        [HttpPut("{id}")]
        public void PutPerson(long id, Person person)
        {
            if (person == null || id != person.Id)
            {
                return;
            }

            try
            {
                db.UpdatePerson(person);
            }
            catch (Exception)
            {

                throw;
            }           
        }

        // POST: api/Profile
        [HttpPost]
        public Person PostPerson(Person person)
        {
            db.AddPerson(person);          

            return person;
        }

        // DELETE: api/Profile/5
        [HttpDelete("{id}")]
        public Person DeletePerson(string id)
        {
            var person = db.GetPersonById(id);

            db.RemovePerson(person);

            return person;
        }

        [HttpPost("[action]")]
        public bool PersonLoadPhoto(string login, string password, string path)
        {
            var t = db.PersonLoadPhoto(login, password, path);
            return t;
        }


        [HttpGet("[action]")]
        public bool PersonSaveCredentials(string login, string password, string firstName, string lastName, string email, string sex, string phone, string isDeleted, string isBanned)
        {
            var t = db.PersonSaveCredentials(login, password, firstName, lastName, email, sex, phone, isDeleted, isBanned);
            return t;
        }

    }
}
