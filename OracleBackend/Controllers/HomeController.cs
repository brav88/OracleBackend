using Microsoft.AspNetCore.Mvc;
using OracleBackend.Models;
using System.Data;
using System.Diagnostics;

namespace OracleBackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //DatabaseHelper.OracleDatabase.InsertPerson("Jason", "Taylor");
            //DatabaseHelper.OracleDatabase.DeletePerson(21);
            //DatabaseHelper.OracleDatabase.UpdatePerson("Travis", "Scott", 7);
            DataTable ds = DatabaseHelper.OracleDatabase.GetPersons();

            List<Person> persons = new List<Person>();
            foreach (DataRow item in ds.Rows)
            {
                persons.Add(new Person
                {
                    FirstName = item["first_name"].ToString(),
                    LastName = item["last_name"].ToString()
                });
            }

            ViewBag.Persons = persons;

            return View();
        }

        public class Person
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}