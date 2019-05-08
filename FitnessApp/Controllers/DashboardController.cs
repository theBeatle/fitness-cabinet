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
    [Route("api/[controller]/[action]")]
    public class DashboardController : Controller
    {
        private readonly ClaimsPrincipal _caller;
        private readonly ApplicationContext _appDbContext;

        public DashboardController(UserManager<Person> userManager, ApplicationContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _appDbContext = appDbContext;
        }

        // GET api/dashboard/home
        [HttpGet]
        public async Task<IActionResult> Home()
        {
            // retrieve the user info
            //HttpContext.User
            var userId = _caller.Claims.Single(c => c.Type == "id");
            var customer = await _appDbContext.Users.Include(c => c.Id).SingleAsync(c => c.Id == userId.Value);

            return new OkObjectResult(new
            {
                Message = "This is secure API and user data!",
                customer.FirstName,
                customer.LastName,
                customer.PictureUrl,
                customer.FacebookId
            });
        }
    }
}