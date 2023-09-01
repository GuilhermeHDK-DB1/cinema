using Cinema.Dominio.Entities.Clientes;

namespace Cinema.Dominio.Dtos.Clientes
{
    public class ClienteResult
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public bool Ativo { get; set; }
        
        public ClienteResult(Cliente cliente)
        {
            Id = cliente.Id;
            Nome = cliente.Nome;
            Cpf = cliente.Cpf;
            Email = cliente.Email;
            DataDeNascimento = cliente.DataDeNascimento;
            Ativo = cliente.Ativo;
        }
    }
}
