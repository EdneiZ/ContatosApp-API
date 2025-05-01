using System.ComponentModel.DataAnnotations;

namespace ContatosApp.API.Models
{
    public class ContatosPostModel
    {
        [MinLength(8, ErrorMessage ="Informe no minimo {1} caracteres")]
        [MaxLength(100, ErrorMessage ="Informe no maximo {1} caracteres")]
        [Required(ErrorMessage ="Informe o nome do contato")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage ="Informe um endereço de email valido. Ex email@email.com")]
        [Required(ErrorMessage = "Informe um email")]
        public string? Email { get; set; }

        [RegularExpression(@"\(\d{2}\)\s\d{5}-\d{4}",
            ErrorMessage = "Por favor, informe um telefone no formato: '(99) 99999-9999'.")]
        [Required(ErrorMessage ="Informe o numero de telefone")]

        public string? Telefone { get; set; }
    }
}
