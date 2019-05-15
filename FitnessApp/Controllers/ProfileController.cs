﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitnessApp.Models.DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FitnessApp.ViewModels;
using System.Security.Claims;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequireHttps]
    //[Authorize(Policy = "Person")]
    public class ProfileController : ControllerBase
    {
        private readonly ClaimsPrincipal _caller;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ApplicationContext db;
        private readonly UserManager<Person> _userManager;


        public ProfileController(IHostingEnvironment env, ApplicationContext dB, UserManager<Person> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _hostingEnvironment = env;
            _caller = httpContextAccessor.HttpContext.User;
            db = dB;
            _userManager = userManager;
        }


        // GET: api/People
        //[HttpGet, DisableRequestSizeLimit]
        //public async Task<ActionResult<IEnumerable<string>>> GetSexStatuses()
        //{
        //    try
        //    {     var sexes = await db.SexStatus.Select(s => s.Sex).Distinct().ToListAsync();
        //        //var sexes = sexStats..ToList(); ;
        //        //return await db.SexStatus.ToListAsync();
        //        return sexes;
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}

        [HttpGet("Profile")]
        public async Task<IActionResult> Profile()
        {
            var request = this.Request;
            Person person = null;
            Claim id = null;
            try
            {
                id = _caller?.Claims?.Single(c => c.Type == "id");
                person = await _userManager.FindByIdAsync(id.Value);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return new OkObjectResult(new
            {
                Message = "This is secure API and user data!",
                person.FirstName,
                person.LastName,
                person.UserName
            });
        }


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
