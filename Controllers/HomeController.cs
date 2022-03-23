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

        public HomeController(ILogger<HomeController> logger, AppointmentContext temp)
        {
            _logger = logger;
            aContext = temp;
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
            return RedirectToAction("Index");//Change this to go to the next group info form later
        }

        [HttpGet]
        public IActionResult ViewAppointments()
        {
            DateTime now = DateTime.Now;

            List<Appointment> apps = aContext.Appointments.Where(x => x.Date >= now).ToList();

            return View(apps);
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

                return RedirectToAction("Index");
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

                return RedirectToAction("Index");
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
