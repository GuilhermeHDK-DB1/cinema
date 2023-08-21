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

        public Cliente(string nome)
        {
            ValidadorDeRegra.Novo()
                .Quando(string.IsNullOrEmpty(nome), Resources.GeneroInvalido)
                .DispararExcecaoSeExistir();

            Nome = nome;
            Ingressos = new List<Ingresso>();
        }
    }
}
