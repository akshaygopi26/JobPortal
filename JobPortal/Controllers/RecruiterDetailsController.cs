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
    public class RecruiterDetailsController : Controller
    {
        private readonly JobPortalContext _context;
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RecruiterDetailsController(JobPortalContext context, SignInManager<IdentityUser> signinManager, UserManager<IdentityUser> userManager)
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
        public async Task<ActionResult> SignUp(RecruiterViewModel model)
        {

            if (ModelState.IsValid)
            {
                RecruiterDetails user = new RecruiterDetails
                {
                    UserName = model.Email,
                    CompanyName = model.CompanyName,
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


        //[HttpPost]
        //public async Task<ActionResult> LogIn(RecruiterLogInViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        RecruiterDetails user = new RecruiterDetails
        //        {
        //            Email = model.Email
        //            // Email = model.Email
        //            //Password = model.Password,
        //            //Mobile = model.Mobile

        //        };
        //        await _signinManager.SignInAsync(user, isPersistent: false);
        //        return RedirectToAction("Index", "Home");
        //        //var userdetails = await _context.UserDetails
        //        //.SingleOrDefaultAsync(m => m.Email == model.Email && m.Password == model.Password);
        //        /*if (userdetails == null)
        //        {
        //            ModelState.AddModelError("Password", "Invalid login attempt.");
        //            return View("Index");
        //        }
        //        HttpContext.Session.SetString("userId", userdetails.Name);
        //        */

        //    }
        //    else
        //    {
        //        return View(model);
        //    }
        //    return RedirectToAction("Index", "Home");
        //}

        [HttpPost]
        public async Task<ActionResult> LogIn(RecruiterLogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signinManager.PasswordSignInAsync(
                    model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("ViewJobsRecruiter", "JobDetails");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }

            return View(model);
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }





    }
}
