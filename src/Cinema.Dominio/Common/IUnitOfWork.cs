namespace Cinema.Dominio.Common
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
