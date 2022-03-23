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
        public IActionResult SignUp(Appointment model)
        {
            return RedirectToAction("Add", model);//Make sure this is returning to the right place
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
        public IActionResult Add(Appointment model)
        {
            return View("Form", model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Appointment app = aContext.Appointments.FirstOrDefault(x => x.AppointmentID == id);

            return View("Delete", app);
        }

        [HttpPost]
        public IActionResult Delete(Appointment app)
        {
            // Delete from DB
            aContext.Appointments.Remove(app);
            aContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var appointment = aContext.Appointments
                .Single(x => x.AppointmentID == id);

            return View("Form", appointment);
        }

        [HttpPost]
        public IActionResult Form(Appointment a)
        {
            if (ModelState.IsValid)
            {
                if (a.AppointmentID == 0)
                {
                    aContext.Add(a);
                    aContext.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    aContext.Update(a);
                    aContext.SaveChanges();

                    return RedirectToAction("Index");
                }
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
