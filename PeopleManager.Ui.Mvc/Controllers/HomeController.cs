﻿using Microsoft.AspNetCore.Mvc;
using PeopleManager.Ui.Mvc.Core;
using PeopleManager.Ui.Mvc.Models;
using System.Diagnostics;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly PeopleManagerDatabase _database;
        
        public HomeController(PeopleManagerDatabase database)
        {
            _database = database;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var people = _database.People;
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
            var people = _database.People;
            var person = people.FirstOrDefault(p => p.Id == id);

            if (person is null)
            {
                return RedirectToAction("Index");
            }

            return View("PersonDetail", person);
        }

        
    }
}