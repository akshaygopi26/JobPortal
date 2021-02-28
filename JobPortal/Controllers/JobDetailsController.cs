using JobPortal.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Controllers
{
    public class JobDetailsController : Controller
    {
        private readonly JobPortalContext _context;

        public JobDetailsController(JobPortalContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> ViewJobs()
        {
            var jobPortalContext = _context.JobDetails.Include(a => a.PostedRecruiter);
            return View(await jobPortalContext.ToListAsync());
        }

        public IActionResult Addjob()
        {
            ViewData["PostedRecruiterId"] = new SelectList(_context.RecruiterDetails, "Id", "Id");
            return View();
        }





    }
}
