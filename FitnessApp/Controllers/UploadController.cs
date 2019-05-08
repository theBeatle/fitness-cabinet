using System;
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


        public UploadController(IHostingEnvironment env, ApplicationContext dB, UserManager<Person> userManager)
        {
            _hostingEnvironment = env;
          
            db = dB;
            _userManager = userManager;
        }

        private async Task LoadFile(string name, string path)
        {           
            var person = await _userManager.FindByNameAsync(name);
            var photo = new Photo() { Path = path };
            var perPhoto = new PersonPhoto() { Person = person, Photo = photo };

            db.Photos.Add(photo);
            db.SaveChanges();
        }


        // GET: api/People
        //[HttpGet, DisableRequestSizeLimit]
        //public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        //{
        //    try
        //    {
        //        return await _userManager.Users.ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }           
        //}


        // PUT: api/People/5
        [HttpPut/*("{id}")*/]
        public async Task<IActionResult> PutPerson(/*long id,*/ Person person)
        {
            var oldPerson = await _userManager.FindByNameAsync("string");

            //       userName: string
            //firstName:string;
            //       lastName: string;
            //       email: string;
            //       sexStatusId: number;
            //       phoneNumber: string;
            //       isDeleted: boolean;
            //       isBanned: boolean;

            oldPerson.FirstName = person.FirstName;
            oldPerson.LastName = person.LastName;
            oldPerson.Email = person.Email;
            oldPerson.SexStatus = new SexStatus { Sex = "default" }; //         SexStatusId = person.SexStatusId;
            oldPerson.PhoneNumber = person.PhoneNumber;
            oldPerson.IsDeleted = person.IsDeleted;
            oldPerson.IsBanned = person.IsBanned;
            //SexStatus 
            
            //IdentityResult result = await UserManager.UpdateAsync(user);
            //db.Entry(person).State = EntityState.Modified;

            try
            {
                var result = await _userManager.UpdateAsync(oldPerson);
                await db.SaveChangesAsync();
               
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (oldPerson==null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                
            }

            return NoContent();
        }


        // GET: api/Person
        [HttpGet, DisableRequestSizeLimit]
        public async Task<ActionResult<Person>> GetPerson()
        {
            try
            {
                return await _userManager.FindByNameAsync("string");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


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
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        //private async Task<IActionResult> PersonExists(string name)
        //{
        //    //return _context.People.Any(e => e.Id == id);
        //    return await _userManager.FindByNameAsync("string");
        //}
    }
}