using Microsoft.AspNetCore.Mvc;
using PeopleManager.Ui.Mvc.Models;
using System.Diagnostics;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var people = GetPeople();
            return View(people);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var people = GetPeople();
            var person = people.FirstOrDefault(p => p.Id == id);

            if (person is null)
            {
                return RedirectToAction("Index");
            }

            return View("PersonDetail", person);
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