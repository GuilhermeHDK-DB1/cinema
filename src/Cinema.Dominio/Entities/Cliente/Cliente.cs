using Cinema.Dominio.Common;

namespace Cinema.Dominio.Entities.Cliente
{
    public class Cliente : Entidade
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public bool Ativo { get; set; }
    }
}
