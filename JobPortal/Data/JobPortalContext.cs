using JobPortal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Data
{
    public class JobPortalContext : IdentityDbContext
    {
        public JobPortalContext(DbContextOptions<JobPortalContext> options)
           : base(options)
        {

        }

        public DbSet<RecruiterDetails> RecruiterDetails { get; set; }
        public DbSet<JobDetails> JobDetails { get; set; }
        public DbSet<ApplicantJobsRelation> ApplicantJobsRelation { get; set; }
        public DbSet<QualificationDetails> QualificationDetails { get; set; }
        public DbSet<ApplicantDetails> ApplicantDetails { get; set; }

    }
}


//public class DisscussionForumContext : IdentityDbContext<UserAccount, IdentityRole<int>, int>//,IdentityRole<int>,int>/*DbContext*/