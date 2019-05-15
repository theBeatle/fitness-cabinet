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
using System.Security.Claims;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequireHttps]
    [Authorize(Policy = "Person")]
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

        [HttpGet]
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
    }
}
