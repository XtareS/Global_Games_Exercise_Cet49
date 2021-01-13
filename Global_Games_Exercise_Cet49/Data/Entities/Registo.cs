﻿
namespace Global_Games_Exercise_Cet49.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;


    public class Registo
    {


        public int Id { get; set; }

        [Required]
        [Display(Name = " ")]
        public string Name { get; set; }



        [Required]
        [Display(Name = " ")]
        public string Sur { get; set; }

        [Required]
        [Display(Name = " ")]
        public string Adress { get; set; }


        [Required]
        [Display(Name = " ")]
        public string Local { get; set; }


        [Required]
        [Display(Name = " ")]
        public string CC { get; set; }



        [Required]
        [Display(Name = " ")]
        public DateTime Birth { get; set; }




    }
}
