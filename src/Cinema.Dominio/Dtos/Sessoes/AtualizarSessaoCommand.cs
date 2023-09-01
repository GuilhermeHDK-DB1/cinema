using Cinema.Dominio.Entities.Sessoes;

namespace Cinema.Dominio.Dtos.Sessoes
{
    public class AtualizarSessaoCommand
    {
        public int Id { get; set; }
        public int FilmeId { get; set; }
        public int SalaId { get; set; }
        public string Horario { get; set; }
        public Idiomas Idioma { get; set; }
    }
}
