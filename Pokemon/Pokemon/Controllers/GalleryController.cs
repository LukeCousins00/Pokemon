using Microsoft.AspNetCore.Mvc;

namespace Pokemon.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View("ballbag");
        }
    }
}
