using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace test_mvc.Models
{
    public class CampusViewModel
    {
        [Required]
        [Display(Name = "Campus_Id")]
        public int Campus_Id { get; set; }

        [Required]
        [Display(Name = "Institute_Id")]
        public int Institute_Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Campus Name")]
        public string CampusName { get; set; }


        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        //[Required]
        //[Display(Name = "UpdatedDate")]
        //public DateTime UpdatedDate { get; set; }


        [Required]
        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

        //[Required]
        //[Display(Name = "UpdatedBy")]
        //public DateTime UpdatedBy { get; set; }

        //[Required]
        //[Display(Name = "IsActive")]
        //public bool IsActive { get; set; }

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
        [Display(Name = "city")]
        public long CityId { get; set; }

     
        public DateTime CreatedDate { get; internal set; }
    }


        public enum city
        {
            [Description("Lahore")]
            Lahore = 1,
            [Description("Karachi")]
            Karachi = 2,
            [Description("Faisalabad")]
            Faisalabad = 3,
            [Description("Rawalpindi")]
            Rawalpindi = 4,
            [Description("Gujranwala")]
            Gujranwala = 5,
            [Description("Peshawar")]
            Peshawar = 6,
            [Description("Multan")]
            Multan = 7,
            [Description("Heiderabad")]
            Heiderabad = 8,
            [Description("Islamabad")]
            Islamabad = 9,
            [Description("Quetta")]
            Quetta = 10,
            [Description("Bahawalpur")]
            Bahawalpur = 11,
            [Description("Sukkur")]
            Sukkur = 12,
            [Description("Kandhkot")]
            Kandhkot = 13,
            [Description("Sheikhupura")]
            Sheikhupura = 14,
            [Description("Mardan")]
            Mardan = 15,
            [Description("Gujrat")]
            Gujrat = 16,
            [Description("Larkana")]
            Larkana = 17,
            [Description("Kasur")]
            Kasur = 18,
            [Description("Rahim Yar Khan")]
            RahimYarKhan = 19,
            [Description("Sahiwal")]
            Sahiwal = 20,
            [Description("Okara")]
            Okara = 21,
            [Description("Wah Cantonment")]
            WahCantonment = 22,
            [Description("Dera Ghazi Khan")]
            DeraGhaziKhan = 23,
            [Description("Mingora")]
            Mingora = 24,
            [Description("Mirpur Khas")]
            MirpurKhas = 25,
            [Description("Chiniot")]
            Chiniot= 26,
            
        }
    }
