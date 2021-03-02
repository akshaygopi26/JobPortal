using JobPortal.Data;
using JobPortal.Models;
using JobPortal.Models.View_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobPortal.Controllers
{
    public class QualificationDetailsController : Controller
    {

        private readonly JobPortalContext _context;
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly UserManager<IdentityUser> _userManager;
       
        public QualificationDetailsController(JobPortalContext context, SignInManager<IdentityUser> signinManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _signinManager = signinManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditQualificationViewModel model)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

           // bool ifExist = _context.QualificationDetails.Contains
            if (ModelState.IsValid)
            {
                QualificationDetails quali = new QualificationDetails
                {
                    ApplicantDetailsId = id,
                    TenthPercentage =model.TenthPercentage,
                    TwelthPercentage = model.TwelthPercentage,
                    HighestQualifcation =model.HighestQualifcation
                };
            }








            
            if (id == null)
            {
                return NotFound();
            }

            var qualification = await _context.QualificationDetails.   FindAsync(id);
            if (qualification == null)
            {
                return NotFound();
            }
            //ViewData["QualifcationId"] = new SelectList(_context.QualificationDetails, "Id", "Id", qualification.ApplicantDetailsId);
            return View(qualification);
        }
    }
}
