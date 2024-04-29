using Microsoft.AspNetCore.Mvc;

namespace DMB.IdentityMessage.PresentationLayer.ViewComponents.UILayoutComponents
{
    public class UILayoutScriptComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
