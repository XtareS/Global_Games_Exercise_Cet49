
namespace Global_Games_Exercise_Cet49.Models
{
    using System.ComponentModel.DataAnnotations;



    public class ChangeUxerViewModel
    {


        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

    }
}
