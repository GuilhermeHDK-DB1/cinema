namespace Cinema.Dominio.Common
{
    public interface IRepositorio<TEntidade>
    {
        TEntidade ObterPorId(int id);
        List<TEntidade> ObterTodos();
        void Adicionar(TEntidade entity);
        void Excluir(TEntidade entity);
    }
}
