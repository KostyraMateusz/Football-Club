using Microsoft.AspNetCore.Mvc;

namespace FootballClubPresentationLayer.ControllersMVC
{
    public class HomeControllerMVC : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
