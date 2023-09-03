using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Filmes;
using Cinema.Dominio.Entities.Ingressos;
using Cinema.Dominio.Entities.Salas;

namespace Cinema.Dominio.Entities.Sessoes
{
    public class Sessao : Entidade
    {
        public Filme Filme { get; set; }
        public Sala Sala { get; set; }
        public DateTime Horario { get; set; }
        public Idiomas Idioma { get; set; }
        public List<Ingresso> Ingressos { get; set; }

        public Sessao()
        {
            Ingressos = new List<Ingresso>();
        }

        public Sessao(Filme filme, Sala sala, DateTime horario, Idiomas idioma)
        {
            Filme = filme;
            Sala = sala;
            Horario = horario;
            Idioma = idioma;

            Ingressos = new List<Ingresso>();
        }

        public void AlterarFilme(Filme filme)
        {
            Filme = filme;
        }

        public void AlterarSala(Sala sala)
        {
            Sala = sala;
        }

        public void AlterarHorario(DateTime horario)
        {
            Horario = horario;
        }

        public void AlterarIdioma(Idiomas idioma)
        {
            Idioma = idioma;
        }
    }
}
