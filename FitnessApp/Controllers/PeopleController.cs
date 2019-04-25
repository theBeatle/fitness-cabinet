using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessApp.Models.DB;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        private readonly ApplicationContext _context;
        //there was some change 
        public PeopleController(ApplicationContext context)
        {
            this._context = context;
            if (!_context.Users.Any())
            {
               // _context.Users.Add(new Person { /*Name = "Andryi" , SureName = "Lovalskyi" , Age = 33*/ });
                _context.SaveChanges();
            }
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPerson()
        {
            return await _context.Person.ToListAsync();
        }
        //there was some change 
        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(string id, ApplicationContext context)
        {
            //var person = await _context.Person.FindAsync(id);

            //if (person == null)
            //{
            //    return NotFound();    
            //}

            //return person;
           /*!!!!!!Запитати у вчителя!!!!!!*/  Person preson = await context.Person.FirstOrDefaultAsync(x => x.Id == id);
            if (preson == null)
                return NotFound();
            return new ObjectResult(preson);
        }

        // PUT: api/People/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(string id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/People
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(string id)
        {
            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();

            return person;
        }

        private bool PersonExists(string id)
        {
            return _context.Person.Any(e => e.Id == id);
        }
    }
}
