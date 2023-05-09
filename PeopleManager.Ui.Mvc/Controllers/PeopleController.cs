using Microsoft.AspNetCore.Mvc;
using PeopleManager.Ui.Mvc.Models;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class PeopleController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var people = GetPeople();
            return View(people);
        }

        private IList<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person
                {
                    Id = 1,
                    FirstName = "Bavo", 
                    LastName = "Ketels", 
                    Email = "bavo.ketels@vives.be",
                    Description = "Lector"
                },
                new Person{Id = 2,FirstName = "Isabelle", LastName = "Vandoorne", Email = "isabelle.vandoorne@vives.be" },
                new Person
                {
                    Id = 3,
                    FirstName = "Wim", 
                    LastName = "Engelen", 
                    Email = "wim.engelen@vives.be",
                    Description = "Opleidingshoofd"
                },
                new Person{Id = 4,FirstName = "Ebe", LastName = "Deketelaere", Email = "ebe.deketelaere@vives.be" }
            };
        }
    }
}
