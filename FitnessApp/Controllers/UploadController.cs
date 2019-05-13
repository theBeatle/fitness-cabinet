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
using FitnessApp.ViewModels;

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
            await db.SaveChangesAsync();
        }


       // GET: api/People
       //[HttpGet, DisableRequestSizeLimit]
       // public async Task<ActionResult<IEnumerable<SexStatus>>> GetSexStatuses()
       // {
       //     try
       //     {
       //         //return await _userManager.Users.ToListAsync();
       //         return await db.SexStatus.ToListAsync();
       //     }
       //     catch (Exception ex)
       //     {
       //         return StatusCode(500, $"Internal server error: {ex}");
       //     }
       // }




        // PUT: api/Upload
        [HttpPut]
        public async Task<IActionResult> PutPerson(PersonDTO person)
        {
            var oldPerson = await _userManager.FindByNameAsync("string");
            var sex = await db.SexStatus.FirstOrDefaultAsync(p => p.Sex == person.SexStatus);

            if (sex==null)
            {
                sex = new SexStatus { Sex = person.SexStatus.ToLower() };
            }           

            oldPerson.FirstName = person.FirstName;
            oldPerson.LastName = person.LastName;
            oldPerson.Email = person.Email;
            oldPerson.SexStatus = sex;//new SexStatus { Sex = person.SexStatus };
            oldPerson.PhoneNumber = person.PhoneNumber;
            oldPerson.IsDeleted = person.IsDeleted;
            oldPerson.IsBanned = person.IsBanned;           

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
                return StatusCode(500, $"Internal server error: {ex}");
            }

            return NoContent();
        }


        // GET: api/Upload
        [HttpGet, DisableRequestSizeLimit]
        public async Task<ActionResult<PersonDTO>> GetPerson()
        {
            try
            {
                var oldPerson = await _userManager.FindByNameAsync("string");
                var sex =  await db.SexStatus.FirstOrDefaultAsync(s => s.Id == oldPerson.SexStatusId);

                if (sex ==null)
                {
                    sex = new SexStatus { Sex = "male" };
                }
                var sexstatus = sex.Sex;
                
                var newPerson = new PersonDTO {
                    UserName=oldPerson.UserName,
                    FirstName=oldPerson.FirstName,
                    LastName=oldPerson.LastName,
                    Email=oldPerson.Email,
                    SexStatus=sexstatus,
                    PhoneNumber=oldPerson.PhoneNumber,
                    IsDeleted=oldPerson.IsDeleted,
                    IsBanned=oldPerson.IsBanned
                };

                return newPerson;
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
    }
}