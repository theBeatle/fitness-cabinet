using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dal;

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
        [HttpGet("[action]")]
        public ICollection<Person> GetPeople()
        {
            return db.GetAllPeople();
        }

        [HttpGet("[action]")]
        public bool PersonLoadPhoto(string login, string password, string path)
        {
            var t = db.PersonLoadPhoto(login, password, path);
            return t;
        }

    }
}
