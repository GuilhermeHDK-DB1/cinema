using Cinema.Dominio.Entities.Sessoes;

namespace Cinema.Dominio.Dtos.Sessoes
{
    public class CadastrarSessaoCommand
    {
        public int FilmeId { get; set; }
        public int SalaId { get; set; }
        public string Horario { get; set; }
        public Idiomas Idioma { get; set; }
    }
}
