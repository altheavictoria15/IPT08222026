using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication1.Controllers.NewFolder
{
    [Route("peoplepower")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        public static List<Person> people = new List<Person>();
        public PeopleController()
        {
         
        }

        [HttpPost]
        public ActionResult AddPerson(Person person)
        {
            people.Add(person);
            return Created();
        }

        [HttpPut]
        public ActionResult<Person> EditPerson(int id, Person newperson)
        {
            var person = people.Where(m => m.Id == id).FirstOrDefault();
            if (person == null)
            {
                return NotFound();
            }
            person = newperson;
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            var person = people.Where(m => m.Id == id).FirstOrDefault();
            if (person == null)
            {
                return NotFound();
            }
            people.Remove(person);
            return Ok();
        }

        [HttpGet]
        public List<Person> GetPeople()
        {
            return people;
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(int id)
        {
            var person = people.Where(m => m.Id == id).FirstOrDefault();
            if (person == null)
            {
                return NotFound();
            }
            return person;
        } 
    }

    public class Person()
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Firstname { get; set; }
        public DateOnly Birthday { get; set; }
        public int Age { get; set; }
    }
}