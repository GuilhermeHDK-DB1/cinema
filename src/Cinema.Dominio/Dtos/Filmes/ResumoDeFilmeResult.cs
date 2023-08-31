using Cinema.Dominio.Entities.Filmes;
using Cinema.Dominio.Entities.Sessoes;

namespace Cinema.Dominio.Dtos.Filmes
{
    public class ResumoDeFilmeResult
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

        public ResumoDeFilmeResult(Filme filme)
        {
            NomeDoFilme = filme.Nome;
            Duracao = filme.Duracao;
            Classificacao = filme.ClassificacaoString;
            Genero = filme.Genero.Nome;
            var sessao = filme.Sessoes.First();
            Horario = sessao.Horario;
            NomeDaSala = sessao.Sala.Nome;
            SalaVip = sessao.Sala.SalaVip;
            Sala3D = sessao.Sala.Sala3D;
        }

        public ResumoDeFilmeResult(Sessao sessao)
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
