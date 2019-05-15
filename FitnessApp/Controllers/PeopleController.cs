using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessApp.Models.DB;
using Microsoft.AspNetCore.Identity;
//using Dal;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : Controller
    {
        private readonly UserManager<Person> _userManager;
        private readonly ApplicationContext _appDbContext;

        public PeopleController(UserManager<Person> userManager, ApplicationContext appDbContext)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        //GET: api/People
        [HttpGet, DisableRequestSizeLimit]
        public async Task<ActionResult<IEnumerable<string>>> GetSexStatuses()
        {
            try
            {
                var sexes = await _appDbContext.SexStatus.Select(s => s.Sex).Distinct().ToListAsync();
                //var sexes = sexStats..ToList(); ;
                //return await db.SexStatus.ToListAsync();
                return sexes;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
