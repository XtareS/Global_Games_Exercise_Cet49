
namespace Global_Games_Exercise_Cet49.Data.Entities
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public interface IEntity
    {
        int Id { get; set; }

        [Display(Name = "")]
        IFormFile ImageFile { get; set; }


    }
}
