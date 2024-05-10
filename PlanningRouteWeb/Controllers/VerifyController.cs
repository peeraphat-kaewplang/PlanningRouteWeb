using Microsoft.AspNetCore.Mvc;

namespace PlanningRouteWeb.Controllers
{
    public class VerifyController : Controller
    {
        public IActionResult Index()
        {
            var json = System.IO.File.ReadAllText("wwwroot/data/permission.json");
            //Permission permission = JsonSerializer.Deserialize<Permission>(json)!;

            return View(new { text = json });
        }
        [HttpPost]
        public IActionResult Index(string permission)
        {
            return View(new { text = permission } );
        }
    }
}
