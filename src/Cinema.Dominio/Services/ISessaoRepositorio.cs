using Cinema.Dominio.Entities.Sessoes;

namespace Cinema.Dominio.Services
{
    public interface ISessaoRepositorio
    {
        void Adicionar(Sessao entity);
        void Atualizar(Sessao entity);
        void Excluir(Sessao entity);
        Sessao ObterPorChave(int filmeId, int salaId, DateTime horario);
        List<Sessao> ObterTodos();
        List<Sessao> ObterPaginado(int skip, int take);
        IEnumerable<Sessao> ObterSessoesDoDia(DateTime dateTime);
    }
}
