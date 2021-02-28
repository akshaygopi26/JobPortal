using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Models
{
    public class ApplicantJobsRelation
    {
        public int Id { get; set; }

        public string ApplicantId { get; set; }
        [ForeignKey("ApplicantId")]
        public ApplicantDetails ApplicantInfo { get; set; }

        public int JobId { get; set; }
        [ForeignKey("JobId")]
        public JobDetails JobInfo { get; set; }
       
    }
}
