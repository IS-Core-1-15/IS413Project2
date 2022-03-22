using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TempleSignUp.Models;

namespace TempleSignUp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private AppointmentContext aContext { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(string uselessFillerCrapVarriableToBeReplacedLater)
        {
            return View("Index");//Change this to go to the next group info form later
        }

        [HttpGet]
        public IActionResult ViewAppointments()
        {
            return View("ViewAppointments");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        
        [HttpGet]
        public IActionResult Add()
        {
            return View("Form");
        }

        [HttpPost]
        public IActionResult Add(Appointment a)
        {
            if (ModelState.IsValid)
            {
                aContext.Add(a);
                aContext.SaveChanges();

                return RedirectToAction("ViewAppointments");
            }
            else
            {
                return View("Form");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var appointment = aContext.Appointments
                .Single(x => x.AppointmentID == id);

            return View("Form", appointment);
        }

        [HttpPost]
        public IActionResult Edit(Appointment a)
        {
            if (ModelState.IsValid)
            {
                aContext.Update(a);
                aContext.SaveChanges();

                return RedirectToAction("ViewAppointments");
            }
            else
            {
                return View("Form");
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
