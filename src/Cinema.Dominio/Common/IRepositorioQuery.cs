namespace Cinema.Dominio.Common
{
    public interface IRepositorioQuery<TEntidade>
    {
        TEntidade ObterPorId(int id);
        List<TEntidade> ObterTodos();
    }
}
