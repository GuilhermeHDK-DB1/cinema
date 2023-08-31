using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Filmes;
using Cinema.Dominio.Entities.Salas;

namespace Cinema.Dominio.Entities.Sessoes
{
    public class Sessao : Entidade
    {
        public Filme Filme { get; set; }
        public Sala Sala { get; set; }
        public DateTime Horario { get; set; }
        public Idiomas Idioma { get; set; }
        public List<SessaoIngresso> SessoesIngressos { get; set; }

        public Sessao()
        {
            SessoesIngressos = new List<SessaoIngresso>();
        }

        public Sessao(Filme filme, Sala sala, DateTime horario, Idiomas idioma)
        {
            Filme = filme;
            Sala = sala;
            Horario = horario;
            Idioma = idioma;

            SessoesIngressos = new List<SessaoIngresso>();
        }
    }
}
