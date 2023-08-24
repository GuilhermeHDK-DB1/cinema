namespace Cinema.Dominio.Common
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
