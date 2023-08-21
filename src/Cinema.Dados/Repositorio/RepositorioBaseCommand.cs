using Cinema.Dados.Contextos;
using Cinema.Dominio.Common;


namespace Cinema.Dados.Repositorio
{
    public class RepositorioBaseCommand<TEntidade> : IRepositorioCommand<TEntidade> where TEntidade : Entidade
    {
        protected readonly ApplicationDbContext Context;

        public RepositorioBaseCommand(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Adicionar(TEntidade entity)
        {
            Context.Set<TEntidade>().Add(entity);
            Context.SaveChanges();
        }

        public void Atualizar(TEntidade entity)
        {
            Context.Set<TEntidade>().Update(entity);
            Context.SaveChanges();
        }

        public void Excluir(TEntidade entity)
        {
            Context.Set<TEntidade>().Remove(entity);
            Context.SaveChanges();
        }
    }
}
