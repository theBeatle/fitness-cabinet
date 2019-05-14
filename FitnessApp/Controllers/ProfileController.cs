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
    public class ProfileController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ApplicationContext db;
        private readonly UserManager<Person> _userManager;


        public ProfileController(IHostingEnvironment env, ApplicationContext dB, UserManager<Person> userManager)
        {
            _hostingEnvironment = env;
            db = dB;
            _userManager = userManager;
        }

        //private async Task LoadUser(string name, string path)
        //{
        //    var person = await _userManager.FindByNameAsync(name);
        //    var perPhoto = new Person() { UserName = };

        //    await db.SaveChangesAsync();
        //}


        // GET: api/People
        [HttpGet, DisableRequestSizeLimit]
        public async Task<ActionResult<IEnumerable<string>>> GetSexStatuses()
        {
            try
            {     var sexes = await db.SexStatus.Select(s => s.Sex).Distinct().ToListAsync();
                return sexes;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
