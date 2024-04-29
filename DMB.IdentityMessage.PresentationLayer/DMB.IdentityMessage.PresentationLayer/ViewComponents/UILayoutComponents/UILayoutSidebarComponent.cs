using Microsoft.AspNetCore.Mvc;

namespace DMB.IdentityMessage.PresentationLayer.ViewComponents.UILayoutComponents
{
    public class UILayoutSidebarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
   
}
