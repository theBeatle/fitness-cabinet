using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Models.Coach;
using FitnessApp.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealServicesController : ControllerBase
    {
        ApplicationContext db;
        public RealServicesController (ApplicationContext context)
        {
            db = context;
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody] CoachProduct coachProduct)
        {
            if(ModelState.IsValid)
            {
                db.Service.Add(
                    new Service {
                        TrainingName = coachProduct.TrainingName,
                        Description = coachProduct.Description,
                    });
                db.Place.Add(
                    new Place {
                        Name = coachProduct.PlaceName,
                        Description = coachProduct.PlaceDescription,
                        AddressId = (111111111).ToString(), // develop!!!
                        IsSimplePlace = coachProduct.IsSimplePlace,
                        WorkShedule = coachProduct.WorkShedule,
                        Rating = 0,//develop!!!
                    }
                    );
            }
        }
    }
}