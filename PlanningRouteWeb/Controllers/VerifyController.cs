using Microsoft.AspNetCore.Mvc;
using PlanningRouteWeb.Models;
using System.Text.Json;

namespace PlanningRouteWeb.Controllers
{
    public class VerifyController : Controller
    {
        public IActionResult Index()
        {
            var json = System.IO.File.ReadAllText("wwwroot/data/permission.json");
            Permission permission = JsonSerializer.Deserialize<Permission>(json)!;

            return View(permission);
        }
        [HttpPost]
        public IActionResult Index(string permission)
        {
            return View(
                JsonSerializer.Deserialize<Permission>(permission)!
            );
        }
    }
}
