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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var person = _database.People.Find(id);

            if(person is null)
            {
                return RedirectToAction("Index");
            }

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id,Person person)
        {
            var dbPerson = _database.People.Find(id);
            if(dbPerson is null)
            {
                return RedirectToAction("index");
            }
            dbPerson.FirstName = person.FirstName;
            dbPerson.LastName = person.LastName;
            dbPerson.Email = person.Email;
            dbPerson.Description = person.Description;

            _database.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
