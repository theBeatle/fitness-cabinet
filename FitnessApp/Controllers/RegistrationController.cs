using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Helpers;
using FitnessApp.Models.ViewModels;
using FitnessApp.Models.DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ApplicationContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger _logger;
        
        public RegistrationController(UserManager<AppUser> userManager, ILogger<AuthController> logger, IMapper mapper, ApplicationContext appDbContext)
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

            var userIdentity = _mapper.Map<AppUser>(model);

            IdentityResult result = null;
            try
            {
                result = await _userManager.CreateAsync(userIdentity, model.Password);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
            _logger.LogInformation("[SIGN-UP] Created new account");

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            Person person = new Person
            {
                Id = userIdentity.Id,
                FirstName = userIdentity.FirstName,
                LastName = userIdentity.LastName,
                Password = userIdentity.Password,
                Login = userIdentity.Login,
                IsBanned = false,
                IsDeleted = false
            };

            await _appDbContext.Person.AddAsync(person);
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }
    }
}