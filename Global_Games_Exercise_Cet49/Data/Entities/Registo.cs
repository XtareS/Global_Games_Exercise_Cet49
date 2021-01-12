using System;
using System.ComponentModel.DataAnnotations;

namespace Global_Games_Exercise_Cet49.Data.Entities
{
    public class Registo
    {


        public int Id { get; set; }

 
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




    }
}
