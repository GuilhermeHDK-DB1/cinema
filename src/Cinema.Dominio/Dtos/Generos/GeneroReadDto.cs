using Cinema.Dominio.Entities.Generos;

namespace Cinema.Dominio.Dtos.Generos
{
    public class GeneroReadDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public GeneroReadDto(Genero genero)
        {
            Id = genero.Id;
            Nome = genero.Nome;
        }
    }
}
