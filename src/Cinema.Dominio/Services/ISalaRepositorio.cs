using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Salas;

namespace Cinema.Dominio.Services
{
    public interface ISalaRepositorio : IRepositorioBase<Sala>
    {
        Sala ObterPeloNome(string nome);
        IEnumerable<Sala> ObterPorSalaVip();
        IEnumerable<Sala> ObterPorSala3D();
    }
}
