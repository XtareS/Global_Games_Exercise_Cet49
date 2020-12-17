using System.ComponentModel.DataAnnotations;

namespace Global_Games_Exercise_Cet49.Data.Entities
{

    public class Newl
    {

        public int Id { get; set; }



        [Required , Display(Name =" ")]
        public string Mail { get; set; }

    }
}
