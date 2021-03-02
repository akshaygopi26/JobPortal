using JobPortal.Data;
using JobPortal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobPortal.Controllers
{
    public class JobDetailsController : Controller
    {
        private readonly JobPortalContext _context;
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly UserManager<IdentityUser> _userManager;

        public JobDetailsController(JobPortalContext context, SignInManager<IdentityUser> signinManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _signinManager = signinManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> ViewJobsRecruiter()
        {
            var jobPortalContext = _context.JobDetails.Include(a => a.PostedRecruiter);
            return View(await jobPortalContext.ToListAsync());
        }

        public IActionResult AddJobRecruiter()
        {
            //ViewData["PostedRecruiterId"] = new SelectList(_context.RecruiterDetails, "Id", "Id");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddJobRecruiter(JobDetails model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //var user = await _userManager.GetUserAsync(User);
               // var cname = user.CompanyName;
                JobDetails job = new JobDetails
                {
                    Position = model.Position,
                    CompanyName = model.CompanyName,
                    Eligibility = model.Eligibility,
                    MinimumExperienceRequired = model.MinimumExperienceRequired,
                    SkillsRequired = model.SkillsRequired,
                    PostedRecruiterId = userId

                };
                _context.Add(job);
                await _context.SaveChangesAsync();

            }
            else
            {
                //return "abcdef";
                return View("LoginPage");
            }
            return RedirectToAction("ViewJobsRecruiter", "JobDetails");
        }



        public async Task<IActionResult> ViewJobsApplicant()
        {
            var jobPortalContext = _context.JobDetails.Include(a => a.PostedRecruiter);
            return View(await jobPortalContext.ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult> AddJobApplicant(JobDetails model)
        {
            if (ModelState.IsValid)
            {
                JobDetails job = new JobDetails
                {
                    Position = model.Position,
                    CompanyName = model.CompanyName,
                    Eligibility = model.Eligibility,
                    MinimumExperienceRequired = model.MinimumExperienceRequired,
                    SkillsRequired = model.SkillsRequired

                };
                _context.Add(job);
                await _context.SaveChangesAsync();

            }
            else
            {
                //return "abcdef";
                return View("LoginPage");
            }
            return RedirectToAction("ViewJobsRecruiter", "JobDetails");
        }




    }
}
