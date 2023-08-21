using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Generos;

namespace Cinema.Dominio.Services
{
    public interface IGeneroRepositorio : IRepositorioQuery<Genero>, IRepositorioCommand<Genero>
    {
        Genero ObterPeloNome(string nome);
    }
}
