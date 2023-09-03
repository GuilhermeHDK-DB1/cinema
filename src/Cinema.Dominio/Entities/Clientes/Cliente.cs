using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Ingressos;

namespace Cinema.Dominio.Entities.Clientes
{
    public class Cliente : Entidade
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Ingresso> Ingressos { get; set; }

        public Cliente()
        {
            Ativo = true;
            Ingressos = new List<Ingresso>();
        }

        public Cliente(string nome, string cpf, string email, DateTime dataDeNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            DataDeNascimento = dataDeNascimento;

            Ativo = true;
            Ingressos = new List<Ingresso>();
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarDataDeNascimento(DateTime dataDeNascimento)
        {
            DataDeNascimento = dataDeNascimento;
        }

        public void AlterarCpf(string cpf)
        {
            Cpf = cpf;
        }

        public void AlterarEmail(string email)
        {
            Email = email;
        }

        public void Desativar()
        {
            Ativo = false;
        }

        public void Ativar()
        {
            Ativo = true;
        }
    }
}
