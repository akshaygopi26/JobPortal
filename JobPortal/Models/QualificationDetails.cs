using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Models
{
    public class QualificationDetails
    {
        [Key]
        public int QualificationId { get; set; }

        public string ApplicantDetailsId { get; set; }
        [ForeignKey("ApplicantDetailsId")]
        public ApplicantDetails Applicant { get; set; }
        
        
       // public ApplicantDetails Applicant { get; set; }

        public int TenthPercentage { get; set; }

        public int TwelthPercentage { get; set; }

        public string HighestQualifcation { get; set; }
    }
}
