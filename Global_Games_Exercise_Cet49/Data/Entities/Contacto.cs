using System.ComponentModel.DataAnnotations;

namespace Global_Games_Exercise_Cet49.Data.Entities
{
    public class Contacto
    {

        public int Id { get; set; }

        [Required, Display(Name = "Nome do Cliente")]
        public string Name { get; set; }

        [Required, Display(Name = "Email de contacto")]
        public string Mail { get; set; }


        [Required, Display(Name = "Escreva aqui a sua mensagem")]
        public string Mensage { get; set; }

    }
}
