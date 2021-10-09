using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test_mvc.Models
{
    public class InstituteProfileModel
    {

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Url")]
        public string Url { get; set; }

        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }


        [Display(Name = "Institute_Id")]
        public int Institute_Id { get; set; }


    }
}