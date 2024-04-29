using Microsoft.AspNetCore.Mvc;

namespace DMB.IdentityMessage.PresentationLayer.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
