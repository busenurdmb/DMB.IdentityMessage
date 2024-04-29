using Microsoft.AspNetCore.Mvc;

namespace DMB.IdentityMessage.PresentationLayer.ViewComponents.UILayoutComponents
{
    public class UILayoutHeadComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
