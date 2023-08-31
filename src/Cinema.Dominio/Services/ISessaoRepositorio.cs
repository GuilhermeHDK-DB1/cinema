using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Sessoes;

namespace Cinema.Dominio.Services
{
    public interface ISessaoRepositorio : IRepositorioBase<Sessao>
    {
        IEnumerable<Sessao> ObterSessoesDoDia(DateTime dateTime);
    }
}
