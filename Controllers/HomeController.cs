using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Validation.Models;
using Validation.Repository;

namespace Validation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRegistrationRepository _registrationRepository;

        public HomeController(ILogger<HomeController> logger, IRegistrationRepository registrationRepository)
        {
            _logger = logger;
            _registrationRepository = registrationRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Registration()
        {
            var model = new RegistraionModel();
            model.ContactPreferences = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            model.ContactPreferences.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = "Phone", Value = "1", Selected = false });
            model.ContactPreferences.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = "Email", Value = "2", Selected = false });
            model.ContactPreferences.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = "Postal", Value = "3", Selected = false });

            return View(model);
        }

        [HttpPost]
        public IActionResult Registration(RegistraionModel model)
        {
            _registrationRepository.SaveRegistration(model);
                return RedirectToAction("ViewFormData", model);
        }
        public IActionResult ViewFormData(RegistraionModel model)
        {
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
