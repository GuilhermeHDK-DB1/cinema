using Cinema.Dominio.Entities.Filmes;
using Cinema.Dominio.Entities.Salas;

namespace Cinema.Dominio.Entities.Sessoes
{
    public class Sessao
    {
        public Filme Filme { get; set; }
        public Sala Sala { get; set; }
        public DateTime Horario { get; set; }
        public Idiomas Idioma { get; set; }
    }
}
