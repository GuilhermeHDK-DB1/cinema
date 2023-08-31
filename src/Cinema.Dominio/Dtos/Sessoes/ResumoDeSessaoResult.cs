using Cinema.Dominio.Entities.Sessao;

namespace Cinema.Dominio.Dtos.Sessoes
{
    public class ResumoDeSessaoResult
    {
        public string NomeDoFilme { get; set; }
        public int Duracao { get; set; }
        public string Classificacao { get; set; }
        public string Genero { get; set; }
        public DateTime Horario { get; set; }
        public Idiomas Idioma { get; set; }
        public string NomeDaSala { get; set; }
        public bool SalaVip { get; set; }
        public bool Sala3D { get; set; }

        public ResumoDeSessaoResult(FilmeSala sessao)
        {
            NomeDoFilme = sessao.Filme.Nome;
            Duracao = sessao.Filme.Duracao;
            Classificacao = sessao.Filme.ClassificacaoString;
            Genero = sessao.Filme.Genero.Nome;
            Horario = sessao.Horario;
            NomeDaSala = sessao.Sala.Nome;
            SalaVip = sessao.Sala.SalaVip;
            Sala3D = sessao.Sala.Sala3D;
        }
    }
}
