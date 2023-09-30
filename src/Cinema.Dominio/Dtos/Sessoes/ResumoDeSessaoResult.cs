using Cinema.Dominio.Entities.Sessoes;

namespace Cinema.Dominio.Dtos.Sessoes
{
    public class ResumoDeSessaoResult
    {
        public int Id { get; set; }
        public string NomeDoFilme { get; set; }
        public int Duracao { get; set; }
        public string Classificacao { get; set; }
        public string Genero { get; set; }
        public DateTime Horario { get; set; }
        public Idiomas Idioma { get; set; }
        public string NomeDaSala { get; set; }
        public bool SalaVip { get; set; }
        public bool Sala3D { get; set; }
        public int CapacidadeDisponivel { get; set; }

        public ResumoDeSessaoResult()
        {

        }

        public ResumoDeSessaoResult(Sessao sessao)
        {
            Id = sessao.Id;
            NomeDoFilme = sessao.Filme.Nome;
            Duracao = sessao.Filme.Duracao;
            Classificacao = sessao.Filme.ClassificacaoString;
            Genero = sessao.Filme.Genero.Nome;
            Horario = sessao.Horario;
            NomeDaSala = sessao.Sala.Nome;
            SalaVip = sessao.Sala.SalaVip;
            Sala3D = sessao.Sala.Sala3D;
            CapacidadeDisponivel = 0; // TODO
        }
    }
}
