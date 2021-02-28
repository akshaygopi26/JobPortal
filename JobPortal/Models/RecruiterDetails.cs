using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Models
{
    public class RecruiterDetails : IdentityUser
    {

        public int Id { get; set; }

        public string CompanyName { get; set; }


        //  public string Mobile { get; set; }

        //public string Email { get; set; }
        //public string Password { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser UserInfo { get; set; }

        public ICollection<JobDetails> PostedJobs { get; set; }
    }
}
