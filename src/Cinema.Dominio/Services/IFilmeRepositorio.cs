using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Filmes;

namespace Cinema.Dominio.Services
{
    public interface IFilmeRepositorio : IRepositorioBase<Filme>
    {
        Filme ObterPeloNome(string nome);
        IEnumerable<Filme> ObterPorGenero(string genero);
        IEnumerable<Filme> ObterPelaClassificacao(string classificacao);
    }
}
