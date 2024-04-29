using AutoMapper;
using DMB.IdentityMessage.BusinessLayer.Abstract;
using DMB.IdentityMessage.EntityLayer.Entities;
using DMB.IdentityMessage.PresentationLayer.Models.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace DMB.IdentityMessage.PresentationLayer.Controllers
{
    [Authorize]
    public class MailController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        public MailController(IMailService mailService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _mailService = mailService;
            _userManager = userManager;
            _mapper = mapper;
        }

        //Mesaj Gönderme
        [HttpGet]
        public async Task<IActionResult> Compose(int? id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var draft = _mailService.GetDraftMailbyİd(id);
            if (draft != null)
            {
                var draftMail = new ListMailModel()
                {
                    MailId = draft.MailId,
                    MailContent = draft.MailContent,
                    MailSubject = draft.MailSubject,
                    ReceiverId = draft.ReceiverId,
                    ReceiverEmail = _userManager.Users
      .Where(x => x.Id == draft.ReceiverId).FirstOrDefault().Email,

                

            };
              
                return View(draftMail);
            }
            return View();
           

        }
        

        [HttpPost]

        public async Task<JsonResult> Compose(ListMailModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var p = _mapper.Map<Mail>(model);
            
            p.SenderId = user.Id;
            var receiverUser = await _userManager.FindByEmailAsync(model.ReceiverEmail);
            if (receiverUser != null)
            {
                p.ReceiverId = receiverUser.Id;
            }
            p.MailDate = DateTime.Now;
            p.MailTime = DateTime.Now.TimeOfDay;
            if (p.ReceiverId == user.Id)
            {
                ViewBag.EmailError = "Kendinize mail gönderemezsiniz";
                
            }
            p.Sender = null;
            p.Receiver = null;
            p.MailId = 0;
            _mailService.TInsert(p);
            _mailService.DraftDeletebyİd(model.MailId);
            return Json("Ok");


        }
    
        //Taslak Oluşturma

        [HttpPost]
        public async Task<JsonResult> DraftAdd(ListMailModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var p = _mapper.Map<Mail>(model);

            p.SenderId = user.Id;
            var receiverUser = await _userManager.FindByEmailAsync(model.ReceiverEmail);
            if (receiverUser != null)
            {
                p.ReceiverId = receiverUser.Id;
            }
            p.MailDate = DateTime.Now;
            p.MailTime = DateTime.Now.TimeOfDay;
            if (p.ReceiverId == user.Id)
            {
                ViewBag.EmailError = "Kendinize mail gönderemezsiniz";

            }
            p.IsDraft = true;
            p.Sender = null;
            p.Receiver = null;
            //Mail p = new Mail();
            //p.SenderId = user.Id;

            //var receiverUser = await _userManager.FindByEmailAsync(model.ReceiverEmail);
            //if (receiverUser != null)
            //{
            //    p.ReceiverId = receiverUser.Id;
            //}
            //p.MailContent = model.MailContent;
            //p.MailSubject = model.MailSubject;
            //p.MailDate = DateTime.Now;
            //p.MailTime = DateTime.Now.TimeOfDay;
            //p.IsDraft = true;
            //p.IsImportant = false;
            //p.IsJunk = false;
            //p.IsRead = false;
            //p.IsTrash = false;

            //if (p.ReceiverId == user.Id)
            //{
            //    return Json(new { error = "Kendinize mail gönderemezsiniz" });
            //}

            _mailService.TInsert(p);
            return Json("Ok");
        }

        //Mesaj Okuma
        [HttpGet]
        public async Task<IActionResult> ReadMail(int id)
        {
            var mail = _mailService.TGetById(id); 
            mail.IsRead = true;
           _mailService.TUpdate(mail);

            var values=_mailService.TGetByIddto(id);
            var p=_mapper.Map<ListMailModel>(values);
            return View(p);
        }
        //Gelen Mesajlar 
        public async Task<IActionResult> Inbox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var value=_mailService.GetSendandReceiverMailnameListAllbyReceiverId(user.Id);
            return View(_mapper.Map<List<ListMailModel>>(value));
        }
        //Gönderilen Mesajlar
        [HttpGet]
        public async Task<IActionResult> Sendbox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _mailService.GetSendandReceiverMailnameListAllbySenderId(user.Id);
            return View(_mapper.Map<List<ListMailModel>>(value));
        }
        //Taslaklar
        public async Task<IActionResult> Draft()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _mailService.GetSendandReceiverMailnameListAllbyDraftSenderId(user.Id);
            return View(_mapper.Map<List<ListMailModel>>(value));
        }

        //Önemli Mesajlar
        [HttpGet]
        public async Task<IActionResult> Important()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _mailService.GetSendandReceiverMailnameListAllbyİmportId(user.Id);
            return View(_mapper.Map<List<ListMailModel>>(value));
        }

        //Yıldızla
        
        public async Task<IActionResult> MakeImportant(int id, string redirectAction)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var important = _mailService.TGetById(id);

            if (important.IsImportant)
            {
                important.IsImportant = false;
            }
            else
            {
                important.IsImportant = true;
            }
            _mailService.TUpdate(important);
            return RedirectToAction(redirectAction);
        }
        //Spamlı Mesajlar
        [HttpGet]
        public async Task<IActionResult> Junk()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _mailService.GetSendandReceiverMailnameListAllbySpamId(user.Id);
            return View(_mapper.Map<List<ListMailModel>>(value));
        }
        //Spamla
        [HttpPost]
        public async Task<IActionResult> MakeJunk(int id, string redirectAction)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var Junk = _mailService.TGetById(id);

             Junk.IsJunk = true;
            _mailService.TUpdate(Junk);
            return Json("Ok", redirectAction); 
        }
        //Çöp Kutusu
        [HttpGet]
        public async Task<IActionResult> Trash()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _mailService.GetSendandReceiverMailnameListAllbyTrashId(user.Id);
            return View(_mapper.Map<List<ListMailModel>>(value));
        }
        //Çöp Yap
        [HttpPost]
        public async Task<IActionResult> Trash(int id, string redirectAction)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var trash = _mailService.TGetById(id);


            trash.IsTrash = true;
            _mailService.TUpdate(trash);
             return Json("Ok");
        }
        //Sil
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            _mailService.TDelete(id);
            return Json("Ok");
        }
    }
}
