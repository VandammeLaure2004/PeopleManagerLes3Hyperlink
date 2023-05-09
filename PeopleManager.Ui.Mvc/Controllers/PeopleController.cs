using Microsoft.AspNetCore.Mvc;
using PeopleManager.Ui.Mvc.Core;
using PeopleManager.Ui.Mvc.Models;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PeopleManagerDbContext _database;

        public PeopleController(PeopleManagerDbContext database)
        {
            _database = database;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var people = _database.People.ToList();
            return View(people);
        }
        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person) 
        {
            _database.People.Add(person);

            _database.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
