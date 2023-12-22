using Microsoft.AspNetCore.Mvc;

namespace E_CommerceWebApplication.Controllers
{
    public class AboutMe : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
