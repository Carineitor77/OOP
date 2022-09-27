using Microsoft.AspNetCore.Mvc;

namespace OOP.Controllers
{
    public class Lab3Controller : Controller
    {
        public IActionResult Index()
        {
            string[] roles = new string[] { "Eagle", "Duck" };
            return View(roles);
        }
    }
}
