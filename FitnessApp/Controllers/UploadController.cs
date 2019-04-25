using System;
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

namespace FitnessApp.Controllers
{
    public class Dal
    {
        private readonly ApplicationContext db;
        private readonly UserManager<Person> userManager;

       public Dal(ApplicationContext dB, UserManager<Person> UserManager)
        {
            db = dB;
            userManager = UserManager;
        }

        public async Task LoadFile(string id, string path)
        {
           // var count1 = db.Person.Count();
            var person = await userManager.FindByIdAsync(id);
            var photo = new Photo() { Path = path};
            
            var perPhoto = new PersonPhoto() { Person = person, Photo = photo  };

            db.Photos.Add(photo);
        }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ApplicationContext db;
        //readonly Dal db = new Dal(dB, );



        public UploadController(IHostingEnvironment env, ApplicationContext dB)
        {
            _hostingEnvironment = env;
            db = dB;
        }


        [HttpPost("{id}"), DisableRequestSizeLimit]
        public IActionResult Upload(string id)
        {
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

                    //db.PersonLoadPhoto(id, fullPath);                    
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
                return StatusCode(500, "Internal server error");
            }
        }
    }
}