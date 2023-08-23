using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Filmes;

namespace Cinema.Dominio.Services
{
    public interface IFilmeRepositorio : IRepositorioQuery<Filme>
    {
        Filme ObterPeloNome(string nome);
    }
}
