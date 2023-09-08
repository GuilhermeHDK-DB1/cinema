using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Sessoes;

namespace Cinema.Dominio.Services
{
    public interface ISessaoRepositorio : IRepositorioBase<Sessao>
    {
        Sessao ObterPelaSalaEHorario(int salaId, DateTime horario);
        IEnumerable<Sessao> ObterSessoesPelaData(DateTime data);
        IEnumerable<Sessao> ObterSessoesNaoIniciadasPorFilmeEData(int filmeId, DateTime data);
        IEnumerable<Sessao> ObterSessoesNaoIniciadasPorHorario(DateTime horario);
        IEnumerable<Sessao> ObterSessoesNaoIniciadasDoDia();
        int ObterCapacidadeDaSalaPeloId(int id);
    }
}
