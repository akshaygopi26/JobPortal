using JobPortal.Data;
using JobPortal.Models;
using JobPortal.Models.View_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Controllers
{
    public class ApplicantDetailsController : Controller
    {

        private readonly JobPortalContext _context;
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly UserManager<IdentityUser> _userManager;

        public ApplicantDetailsController(JobPortalContext context, SignInManager<IdentityUser> signinManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _signinManager = signinManager;
            _userManager = userManager;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignUp(ApplicantSignUpViewModel model)
        {

            if (ModelState.IsValid)
            {
                ApplicantDetails user = new ApplicantDetails
                {
                    UserName = model.Email,
                    Firstname = model.FirstName,
                    Lastname = model.LastName,
                    Email = model.Email,
                    //Password = model.Password,
                    PhoneNumber = model.Mobile

                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //ReviewerDetails r = new ReviewerDetails
                    //{
                    //    Age = model.Age,
                    //    UserId = user.Id,
                    //    Name = model.Name

                    //};
                    //_context.Add(r);
                    //await _context.SaveChangesAsync();
                    await _signinManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("LogIn", "ApplicantDetails");
                }

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            else
            {
                return View("Index");
            }
            //return RedirectToAction("", "RecruiterDetails");
            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> LogIn(ApplicantLogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signinManager.PasswordSignInAsync(
                    model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }

    }
}
