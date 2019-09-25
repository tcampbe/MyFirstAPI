using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myFirstAPI.Models;


namespace myFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        // set up some test data
        private static readonly List<Person> _people = new List<Person>
             {
                 new Person
                 {
                     Id = 1,
                     Name = "Luke Skywalker",
                     HairColor = "blond"
                 },
                 new Person
                 {
                     Id = 5,
                     Name = "Leia Organa",
                     HairColor = "brown"
                 }
             };

        // GET api/values
        [HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        public IActionResult Get()
        {
            //return new string[] { "value1", "value2" };
            return Ok(_people);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        //public ActionResult<string> Get(int id)
        public IActionResult Get(int id)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);
            if (person == null) return NotFound();
            return Ok(person);
        }
        /* {
            if (id>5)
            {
                return NotFound();
            }
            else
            {
                return Ok(id);
            }
            return "value";
        } */

        // POST api/values
        [HttpPost]
        //public void Post([FromBody] string value)
        public IActionResult Post([FromBody] Person newPerson)
        {
            _people.Add(newPerson);
            return CreatedAtAction("Get", newPerson, new { id = new Random().Next() });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        public IActionResult Put(int id, [FromBody] Person updatedPerson)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);
            if (person == null) return BadRequest();
            person.Name = updatedPerson.Name;
            person.HairColor = updatedPerson.HairColor;

            return Ok(person);
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                _people.Remove(person);
                    //return NoContent();
                return Ok(_people);
            }
            return BadRequest();
        }
    }
}
