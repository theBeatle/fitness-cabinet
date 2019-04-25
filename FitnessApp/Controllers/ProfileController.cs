using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Dal;
using System.IO;
using System.Net.Http.Headers;
using FitnessApp.Models.DB;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        //readonly IDal db = new Edal();

        // GET: api/Workers
        /// <summary>
        /// Read all workers information
        /// </summary>
        /// <returns>Collection of Workers</returns>
        /// 

        //[HttpGet]
        //public ICollection<Person> GetPeople()
        //{
        //    return db.GetAllPeople();
        //}


        //[HttpGet]
        //public IActionResult GetAllUsers()
        //{
        //    try
        //    {
        //        var users = db.GetAllPeople();

        //        return Ok(users);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}


        //[HttpPost]
        //public IActionResult CreatePerson([FromBody]Person user)
        //{
        //    try
        //    {
        //        if (user == null)
        //        {
        //            return BadRequest("User object is null");
        //        }

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest("Invalid model object");
        //        }

        //        db.AddPerson(user);
        //        //user.Id = Guid.NewGuid();
        //        //_context.Add(user);
        //        //_context.SaveChanges();

        //        return StatusCode(201);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}


        //[HttpGet("{id}")]
        //public Person GetPerson(string id)
        //{
        //    var person = db.GetPersonById(id);           

        //    return person;
        //}

        //[HttpPut("{id}")]
        //public void PutPerson(long id, Person person)
        //{
        //    if (person == null || id != person.Id)
        //    {
        //        return;
        //    }

        //    try
        //    {
        //        db.UpdatePerson(person);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }           
        //}

        //// POST: api/Profile
        //[HttpPost]
        //public Person PostPerson(Person person)
        //{
        //    db.AddPerson(person);          

        //    return person;
        //}

        //// DELETE: api/Profile/5
        //[HttpDelete("{id}")]
        //public Person DeletePerson(string id)
        //{
        //    var person = db.GetPersonById(id);

        //    db.RemovePerson(person);

        //    return person;
        //}

        //[HttpPost("[action]")]
        //public bool PersonLoadPhoto(string id, string path)
        //{
        //    var t = db.PersonLoadPhoto(id, path);
        //    return t;
        //}


        //[HttpPut("[action]")]
        //public bool PersonSaveCredentials(string login, string password, string firstName, string lastName, string email, string sex, string phone, string isDeleted, string isBanned)
        //{
        //    var t = db.PersonSaveCredentials(login, password, firstName, lastName, email, sex, phone, isDeleted, isBanned);
        //    return t;
        //}

    }
}
