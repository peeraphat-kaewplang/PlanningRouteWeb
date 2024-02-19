using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PlanningRouteWeb.Models;

namespace PlanningRouteWeb.Controllers
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
            return View();
        }
        [HttpPost]
        public IActionResult Index(string permission)
        {
            return View(
                JsonSerializer.Deserialize<Permission>(permission)!
            );
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}