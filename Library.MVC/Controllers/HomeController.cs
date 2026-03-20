// Used for tracking application activity (used in Error handling)
using System.Diagnostics;

// Import your Models (like ErrorViewModel)
using Library.MVC.Models;

// Import MVC framework (Controller, IActionResult, View etc.)
using Microsoft.AspNetCore.Mvc;

namespace Library.MVC.Controllers
{
    // This is the HOME CONTROLLER
    // It handles requests for the home pages (Index, Privacy, Error)
    public class HomeController : Controller
    {
        // Logger is used to log information, warnings, and errors
        private readonly ILogger<HomeController> _logger;

        // Constructor: Dependency Injection of ILogger
        // ASP.NET automatically provides this logger
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // This method handles requests to: /Home/Index
        // It returns the Index view (Homepage)
        public IActionResult Index()
        {
            return View(); // loads Views/Home/Index.cshtml
        }

        // This method handles: /Home/Privacy
        // It returns the Privacy page view
        public IActionResult Privacy()
        {
            return View(); // loads Views/Home/Privacy.cshtml
        }

        // This method handles errors
        // ResponseCache disables caching for error pages
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Create ErrorViewModel and pass RequestId
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}