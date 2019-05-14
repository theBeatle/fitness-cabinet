using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FitnessApp.Models.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AngularASPNETCore2WebApiAuth.Controllers
{
    [Authorize(Policy = "Person")]
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        private readonly ClaimsPrincipal _caller;
        private readonly UserManager<Person> _userManager;
        private readonly ApplicationContext _appDbContext;

        public DashboardController(UserManager<Person> userManager, ApplicationContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _caller = httpContextAccessor.HttpContext.User;
            _appDbContext = appDbContext;
        }

        // GET api/dashboard/home
        [HttpGet("home")]
        public async Task<IActionResult> Home()
        {
            // retrieve the user info
            //HttpContext.User
            var userId = _caller.Claims.Single(c => c.Type == "id");
            var person = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId.Value);

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