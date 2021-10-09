using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test_mvc.Models
{
    public class InstituteViewModels
    {
        [Required]
        [Display(Name = "Institute_Id")]
        public int Institute_Id { get; set; }

      
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Url")]
        public string Url { get; set; }


        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }


        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        //[Required]
        //[Display(Name = "UpdatedDate")]
        //public DateTime UpdatedDate { get; set; }


        [Required]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        //[Required]
        //[Display(Name = "UpdatedBy")]
        //public string UpdatedBy { get; set; }

        //[Required]
        //[Display(Name = "IsActive")]
        //public bool IsActive { get; set; }


       
        [Display(Name = "Campus")]
        public bool Campus { get; set; }





    }
}