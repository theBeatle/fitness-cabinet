using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Helpers;
using FitnessApp.Models;
using FitnessApp.Models.DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ApplicationContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<Person> _userManager;
        private readonly ILogger _logger;
        public RegistrationController(UserManager<Person> userManager, ILogger<AuthController> logger, IMapper mapper, ApplicationContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
            _logger = logger;
        }

        // POST api/auth/registration
        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<Person>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);
            _logger.LogInformation("[SIGN-UP] Created new account");

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            await _appDbContext.Users.AddAsync(new Person { Id = userIdentity.Id });
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }
    }
}