namespace ContatosApp.API.Models
{
    public class ContatoPutModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }

        public int? Ativo { get; set; }
    }
}
