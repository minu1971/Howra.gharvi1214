using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test_mvc.Models
{
    public class BatchViewModel
    {
        [Required]
        [Display(Name = "Institute_Id")]
        public int Institute_Id { get; set; }

        [Required]
        [Display(Name = "Course_Id")]
        public int Course_Id { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public string Course_Name { get; set; }

        [Required]
        [Display(Name = "Batch Name")]
        public string Batch_Name { get; set; }

        [Required]
        [Display(Name = "Admission Start")]
        public DateTime Admission_Start { get; set; }

        [Required]
        [Display(Name = "Admission End")]
        public DateTime Admission_End { get; set; }

        [Required]
        [Display(Name = "Fee")]
        public string Fee { get; set; }

        [Required]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; internal set; }


        [Display(Name = "Status")]
        public bool Status { get; set; }




    }
}