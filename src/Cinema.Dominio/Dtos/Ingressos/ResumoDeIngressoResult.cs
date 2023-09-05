using Cinema.Dominio.Entities.Ingressos;
using Cinema.Dominio.Entities.Sessoes;

namespace Cinema.Dominio.Dtos.Ingressos
{
    public class ResumoDeIngressoResult
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int SessaoId { get; set; }
        public string NomeDoCliente { get; set; }
        public string NomeDoFilme { get; set; }
        public int Duracao { get; set; }
        public DateTime Horario { get; set; }
        public Idiomas Idioma { get; set; }
        public string NomeDaSala { get; set; }
        public bool SalaVip { get; set; }
        public bool Sala3D { get; set; }

        public ResumoDeIngressoResult(Ingresso ingresso)
        {
            Id = ingresso.Id;
            ClienteId = ingresso.Cliente.Id;
            SessaoId = ingresso.Sessao.Id;
            NomeDoCliente = ingresso.Cliente.Nome;
            NomeDoFilme = ingresso.Sessao.Filme.Nome;
            Duracao = ingresso.Sessao.Filme.Duracao;
            Horario = ingresso.Sessao.Horario;
            Idioma = ingresso.Sessao.Idioma;
            NomeDaSala = ingresso.Sessao.Sala.Nome;
            SalaVip = ingresso.Sessao.Sala.SalaVip;
            Sala3D = ingresso.Sessao.Sala.Sala3D;
        }
    }
}
