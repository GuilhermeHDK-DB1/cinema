namespace Cinema.Dominio.Common
{
    public interface IRepositorioCommand<TEntidade>
    {
        void Adicionar(TEntidade entity);
        void Atualizar(TEntidade entity);
        void Excluir(TEntidade entity);
    }
}
