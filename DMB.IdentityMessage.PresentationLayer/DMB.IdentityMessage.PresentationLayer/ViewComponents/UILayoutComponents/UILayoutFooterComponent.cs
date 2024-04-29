using Microsoft.AspNetCore.Mvc;

namespace DMB.IdentityMessage.PresentationLayer.ViewComponents.UILayoutComponents
{
    public class UILayoutFooterComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
