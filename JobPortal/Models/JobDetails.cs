using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Models
{
    public class JobDetails
    {

        [Key]
        public int JobId { get; set; }
       
        public string CompanyName { get; set; }

        public string Position { get; set; }

        public string Eligibility { get; set; }

        public string SkillsRequired { get; set; }

        public string MinimumExperienceRequired { get; set; }


        public string PostedRecruiterId { get; set; }
        [ForeignKey("PostedRecruiterId")]
        public RecruiterDetails PostedRecruiter { get; set; }
    }
}
