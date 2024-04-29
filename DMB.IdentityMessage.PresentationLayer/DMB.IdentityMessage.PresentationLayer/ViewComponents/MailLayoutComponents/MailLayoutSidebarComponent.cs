using DMB.IdentityMessage.BusinessLayer.Abstract;
using DMB.IdentityMessage.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DMB.IdentityMessage.PresentationLayer.ViewComponents.MailLayoutComponents
{
    public class MailLayoutSidebarComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailService _mailService;

        public MailLayoutSidebarComponent(UserManager<AppUser> userManager, IMailService mailService)
        {
            _userManager = userManager;
            _mailService = mailService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.user=user.Name;
            ViewBag.email = user.Email;
            ViewBag.ImageUrl = user.İmageUrl;
            var Inbox = _mailService.GetSendandReceiverMailnameListAllbyReceiverId(user.Id).Count();
            ViewBag.Inbox = Inbox;

            var Sendbox = _mailService.GetSendandReceiverMailnameListAllbySenderId(user.Id).Count;
            ViewBag.Sendbox = Sendbox;

            var Draft = _mailService.GetSendandReceiverMailnameListAllbyDraftSenderId(user.Id).Count;
            ViewBag.Draft = Draft;

            var Import = _mailService.GetSendandReceiverMailnameListAllbyİmportId(user.Id).Count;
            ViewBag.Import = Import;

            var Trash = _mailService.GetSendandReceiverMailnameListAllbyTrashId(user.Id).Count;
            ViewBag.Trash = Trash;

            var Junk = _mailService.GetSendandReceiverMailnameListAllbySpamId(user.Id).Count;
            ViewBag.Junk = Junk;
            return View();
        }
    }
}
