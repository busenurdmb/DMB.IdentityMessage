using AutoMapper;
using DMB.IdentityMessage.BusinessLayer.Dto;
using DMB.IdentityMessage.BusinessLayer.Validation.Register;
using DMB.IdentityMessage.EntityLayer.Entities;
using DMB.IdentityMessage.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DMB.IdentityMessage.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;
        private readonly IMapper _mapper;

        public RegisterController(UserManager<AppUser> usermanager, IMapper mapper)
        {
            _usermanager = usermanager;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            var dto = _mapper.Map<RegisterViewDto>(model);
            //AppUser appUser = new AppUser()
            //{
            //    Name = model.Name,
            //    Email = model.Email,
            //    SurName = model.Surname,
            //    UserName = model.Username,
            //};
            var validationResult = new CreateRegisterValidatior().Validate(dto);
            //var validationResult = validator.Validate(appUser);

            if (!validationResult.IsValid)
            {
                // Doğrulama başarısız olduğunda hataları gösterin
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(model); // Hatalı modeli tekrar gösterin
            }
          var appUser=_mapper.Map<AppUser>(dto);
            var result = await _usermanager.CreateAsync(appUser, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
