using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
