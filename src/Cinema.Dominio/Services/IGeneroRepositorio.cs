using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Generos;

namespace Cinema.Dominio.Services
{
    public interface IGeneroRepositorio : IRepositorioBase<Genero>
    {
        Genero ObterPeloNome(string nome);
    }
}
