using Cinema.Dominio.Entities.Filmes;
using Cinema.Dominio.Entities.Generos;
using Cinema.Dominio.Entities.Salas;
using Cinema.Dominio.Entities.Sessao;

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

        public ResumoDeFilmeResult
            (string nomeDoFilme, 
            int duracao, 
            string classificacao, 
            string genero, 
            DateTime horario, 
            string nomeDaSala, 
            bool salaVip, 
            bool sala3D)
        {
            NomeDoFilme = nomeDoFilme;
            Duracao = duracao;
            Classificacao = classificacao;
            Genero = genero;
            Horario = horario;
            NomeDaSala= nomeDaSala;
            SalaVip = salaVip;
            Sala3D = sala3D;
        }

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
    }
}
