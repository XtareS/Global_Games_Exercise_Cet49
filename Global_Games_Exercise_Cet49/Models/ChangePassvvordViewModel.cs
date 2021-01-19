
namespace Global_Games_Exercise_Cet49.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ChangePassvvordViewModel
    {

        [Required]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }


        [Required]
        [Display(Name = "Next Password")]
        public string NextPassword { get; set; }


        [Required]
        [Compare("NextPassword")]
        public string Confirm { get; set; }


    }
}
