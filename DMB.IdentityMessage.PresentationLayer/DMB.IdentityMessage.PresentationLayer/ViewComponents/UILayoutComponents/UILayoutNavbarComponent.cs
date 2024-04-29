using Microsoft.AspNetCore.Mvc;

namespace DMB.IdentityMessage.PresentationLayer.ViewComponents.UILayoutComponents
{
    public class UILayoutNavbarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
}
