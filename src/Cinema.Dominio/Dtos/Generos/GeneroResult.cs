using Cinema.Dominio.Entities.Generos;

namespace Cinema.Dominio.Dtos.Generos
{
    public class GeneroResult
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public GeneroResult(Genero genero)
        {
            Id = genero.Id;
            Nome = genero.Nome;
        }
    }
}
