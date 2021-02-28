using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Models
{
    public class ApplicantDetails  : IdentityUser
    {
        
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser UserInfo { get; set; }

        public QualificationDetails Qualification { get; set; }
       
        //public int QualificationId { get; set; }
        //[ForeignKey("QualificationId")]
        //public QualificationDetails Qualification { get; set; }
    }
}
