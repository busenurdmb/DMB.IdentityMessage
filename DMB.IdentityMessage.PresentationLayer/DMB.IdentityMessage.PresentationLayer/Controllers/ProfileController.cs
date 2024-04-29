using AutoMapper;
using DMB.IdentityMessage.BusinessLayer.Abstract;
using DMB.IdentityMessage.BusinessLayer.Dto;
using DMB.IdentityMessage.BusinessLayer.Validation.Password;
using DMB.IdentityMessage.BusinessLayer.Validation.Register;
using DMB.IdentityMessage.EntityLayer.Entities;
using DMB.IdentityMessage.PresentationLayer.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DMB.IdentityMessage.PresentationLayer.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IMailService mailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _mailService = mailService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
          await  LoadUserInformationAsync();

            return View();
        }


        public async Task LoadUserInformationAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = user.Name + user.SurName;
            ViewBag.ımage = user.İmageUrl;
            ViewBag.Inbox = _mailService.GetSendandReceiverMailnameListAllbyReceiverId(user.Id).Count();
            ViewBag.Sendbox = _mailService.GetSendandReceiverMailnameListAllbySenderId(user.Id).Count;
            ViewBag.Import = _mailService.GetSendandReceiverMailnameListAllbyİmportId(user.Id).Count;
            ViewBag.read = _mailService.GetSendandReceiverMailnameListAllbyReadId(user.Id).Count;
        }
        [HttpPost]
        public async Task<IActionResult> Index(PasswordChangeViewModel model)
        {
          await  LoadUserInformationAsync();
            var hasUser = await _userManager.FindByNameAsync(User.Identity.Name);

            var dto = _mapper.Map<PasswordChangeViewDto>(model);
            var validationResult = new PasswordChangeValidator().Validate(dto);

            if (!validationResult.IsValid)
            {
                // Doğrulama başarısız olduğunda hataları gösterin
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(model); // Hatalı modeli tekrar gösterin
            }

            var checkOldPassword = await _userManager.CheckPasswordAsync(hasUser, model.OldPassword); //burada eski şifreyi check yaptırıyoruz.

            if (!checkOldPassword)
            {
                ModelState.AddModelError(string.Empty, "Eski şifreniz yanlıştır.");
                return View(model);
            }

            var result = await _userManager.ChangePasswordAsync(hasUser, model.OldPassword, model.NewPassword);//Yeni şifreyle dğeiştiriyoruz.

            if (!result.Succeeded)
            {
                foreach (IdentityError item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                    return View(model);
                }
            }

            await _userManager.UpdateSecurityStampAsync(hasUser); //nurada şifremizi dğeiştirdikten sonra security stamp güncelledik.
            await _signInManager.SignOutAsync(); //kulllanıcıya yeni şifresiyle girmesi için çıkış yaptırdık 
            await _signInManager.PasswordSignInAsync(hasUser, model.NewPassword, true, false); //kullanıcıya yeni şifresiyle sisteme giriş yaptırdık.



            TempData["PasswordChange"] = "Şifreniz başarıyla değiştirilmiştir.";
            return View();

        }

    }
}

