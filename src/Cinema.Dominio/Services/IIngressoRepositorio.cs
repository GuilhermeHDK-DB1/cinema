using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Ingressos;

namespace Cinema.Dominio.Services
{
    public interface IIngressoRepositorio : IRepositorioBase<Ingresso>
    {
        IEnumerable<Ingresso> ObterIngressosPeloClienteId(int clienteId);
        IEnumerable<Ingresso> ObterIngressosPeloSessaoId(int sessaoId);
    }
}
