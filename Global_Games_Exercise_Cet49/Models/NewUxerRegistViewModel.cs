
namespace Global_Games_Exercise_Cet49.Models
{
    using System.ComponentModel.DataAnnotations;

    public class NewUxerRegistViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        public string UserName { get; set; }


        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string Confirm { get; set; }
    }
}
