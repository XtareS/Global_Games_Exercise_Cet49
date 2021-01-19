
namespace Global_Games_Exercise_Cet49.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;



    public class Registo : AvatUser
    {





        [Display(Name = "  ")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = " ")]
        public string Name { get; set; }


        [Required]
        [Display(Name = " ")]
        public string Sur { get; set; }

        [Required]
        [Display(Name = " ")]
        public string Adress { get; set; }


        [Display(Name = " ")]
        public string Local { get; set; }


        [Required]
        [Display(Name = " ")]
        public string CC { get; set; }



        [Required]
        [Display(Name = " ")]

        public DateTime Birth { get; set; }



        [EmailAddress, Display(Name = " ")]
        public string Email { get; set; }


        public User User { get; set; }


    }
}
