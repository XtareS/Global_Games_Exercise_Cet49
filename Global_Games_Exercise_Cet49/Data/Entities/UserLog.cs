
namespace Global_Games_Exercise_Cet49.Data.Entities
{
    using System.ComponentModel.DataAnnotations;



    public class UserLog
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Limite de 50 Caracteres")]
        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public User User { get; set; }

    }
}
