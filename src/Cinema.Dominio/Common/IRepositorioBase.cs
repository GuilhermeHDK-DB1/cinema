namespace Cinema.Dominio.Common
{
    public interface IRepositorioBase<TEntidade>
    {
        void Adicionar(TEntidade entity);
        void Atualizar(TEntidade entity);
        void Excluir(TEntidade entity);
        TEntidade ObterPorId(int id);
        List<TEntidade> ObterTodos();
        List<TEntidade> ObterPaginado(int skip, int take);
    }
}
