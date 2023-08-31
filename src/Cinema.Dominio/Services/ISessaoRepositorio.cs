using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Sessoes;

namespace Cinema.Dominio.Services
{
    public interface ISessaoRepositorio : IRepositorioBase<Sessao>
    {
        IEnumerable<Sessao> ObterSessoesPelaData(DateTime data);
        IEnumerable<Sessao> ObterSessoesNaoIniciadasPorFilmeEData(int filmeId, DateTime data);
        IEnumerable<Sessao> ObterSessoesNaoIniciadasPorHorario(DateTime horario);
    }
}
