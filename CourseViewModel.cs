using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace test_mvc.Models
{
    public class CourseViewModel
    {
        [Required]
        [Display(Name = "Institute_Id")]
        public int Institute_Id { get; set; }

        [Required]
        [Display(Name = "Course_Id")]
        public int Course_Id { get; set; }


        [Required]
        [Display(Name = "Campus_Id")]
        public int Campus_Id { get; set; }


        [Required]
        [Display(Name = "Campus Name")]
        public string CampusName { get; set; }


        [Required]
        [Display(Name = "Course Name")]
         public String Course_Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public String Description { get; set; }

        [Required]
        [Display(Name = "Level")]
        public int LevelId { get; set; }

        [Required]
        [Display(Name = "Duration")]
        public String Duration { get; set; }

        [Required]
        [Display(Name = "Eligibility")]
        public String Eligibility { get; set; }

        [Required]
        [Display(Name = "Created By")]
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; internal set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }
    }


    public enum Level
    {
        [Description("BS")]
        BS = 1,

        [Description("MS")]
        MS = 2,

        [Description("M.Phil")]
        MPhil = 3,

        [Description("PHD")]
        PHD = 4,

        [Description("Diploma 6 Months")]
        Diploma6Months= 5,

        [Description("Diploma 1 Year")]
        Diploma1Year = 6,

        [Description("Diploma 1.5 Year")]
        Diploma1andhalfYear = 7


    }

 

}