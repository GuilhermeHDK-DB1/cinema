using Cinema.Dominio.Entities.Filmes;
using Cinema.Dominio.Entities.Salas;

namespace Cinema.Dominio.Entities.Sessao
{
    public class FilmeSala
    {
        public Filme Filme { get; set; }
        public Sala Sala { get; set; }
        public DateTime Horario { get; set; }
        public Idiomas Idioma { get; set; }
        public bool Encerrada { get; set; }
    }
}
