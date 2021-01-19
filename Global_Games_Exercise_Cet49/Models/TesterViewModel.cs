namespace Global_Games_Exercise_Cet49.Models
{
    using Global_Games_Exercise_Cet49.Data.Entities;
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class TesterViewModel : Registo
    {

        [Display(Name = "")]
        public IFormFile ImageFile { get; set; }


    }
}