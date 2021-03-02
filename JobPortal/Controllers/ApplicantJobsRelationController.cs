using JobPortal.Data;
using JobPortal.Models;
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
    public class ApplicantJobsRelationController : Controller
    {
        private readonly JobPortalContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ApplicantJobsRelationController(JobPortalContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }





        //public async Task<IActionResult> ViewRating()
        //{

        //    var movieRatingContext = _context.Rating.Include(r => r.Movie).Include(r => r.ReviewerDetails);
        //    return View(await movieRatingContext.ToListAsync());
        //}

        public async Task<ActionResult> ApplyJobApplicant(int? id)
        {
            //ViewData["JobId"] = new SelectList(_context.JobDetails, "JobId", "JobId");
            //  ViewData["ApplicantId"] = new SelectList(_context.Users, "Id", "Id");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == null)
            {
                return NotFound();
            }

            ApplicantJobsRelation job = new ApplicantJobsRelation
            {
                ApplicantId = userId,
                JobId = (int)id
            };
            _context.Add(job);
            await _context.SaveChangesAsync();
            return View();
        }

        //[HttpPost]
        //public async Task<ActionResult> AddRating(Rating model)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        Rating rating = new Rating
        //        {
        //            MovieId = model.MovieId,
        //            ReviewerId = model.ReviewerId,
        //            RatingStar = model.RatingStar,
        //            ReviewComment = model.ReviewComment



        //        };
        //        _context.Add(rating);
        //        await _context.SaveChangesAsync();

        //    }
        //    else
        //    {
        //        return View("Index");
        //    }
        //    return RedirectToAction("Index", "Home");
        //}







        //public IActionResult ApplyJobApplicant()
        //{
        //    return View();
        //}
    }
}
