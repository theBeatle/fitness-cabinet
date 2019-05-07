﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
//using Dal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitnessApp.Models.DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequireHttps]
    //[Authorize]
    public class UploadController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ApplicationContext db;
        private readonly UserManager<Person> _userManager;
        //readonly Dal db = new Dal(dB, );



        public UploadController(IHostingEnvironment env, ApplicationContext dB, UserManager<Person> userManager)
        {
            _hostingEnvironment = env;
          
            db = dB;
            _userManager = userManager;
        }

        private async Task LoadFile(string name, string path)
        {
            // var count1 = db.Person.Count();
            var person = await _userManager.FindByNameAsync(name);
            var photo = new Photo() { Path = path };

            var perPhoto = new PersonPhoto() { Person = person, Photo = photo };

            db.Photos.Add(photo);
            db.SaveChanges();
        }

        //[HttpGet]
        //public async Task<IActionResult> GetPeople()
        //{
        //    try
        //    {
        //        return db.Users();

        //        return Ok(users);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {

            return await _userManager.Users.ToListAsync();
        }


        // [HttpPost, DisableRequestSizeLimit]
        // public ICollection<Person> GetPeople()
        // {
        //     return db.Users();
        // }


        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {            
            //User.Identity.IsAuthenticated -> true
            //var userToVerify = await _userManager.FindByNameAsync(User.Identity.Name);
            
            var person = await _userManager.FindByNameAsync("string");
            string id = person.Id;

            try
            {
                var file = Request.Form.Files[0];

                var folderName = Path.Combine("Resources", "People", id);

                string webRootPath = _hostingEnvironment.WebRootPath;
                string contentRootPath = _hostingEnvironment.ContentRootPath;

                var pathToSave = Path.Combine(contentRootPath, folderName);

                if (!Directory.Exists(pathToSave))
                {
                    Directory.CreateDirectory(pathToSave);
                }

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);

                    await LoadFile(person.UserName, fullPath);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}