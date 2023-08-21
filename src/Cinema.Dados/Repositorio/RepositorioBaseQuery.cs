using Cinema.Dados.Contextos;
using Cinema.Dominio.Common;


namespace Cinema.Dados.Repositorio
{
    public class RepositorioBaseQuery<TEntidade> : IRepositorioQuery<TEntidade> where TEntidade : Entidade
    {
        protected readonly ApplicationDbContext Context;

        public RepositorioBaseQuery(ApplicationDbContext context)
        {
            Context = context;
        }

        public virtual TEntidade ObterPorId(int id)
        {
            var query = Context.Set<TEntidade>().Where(entidade => entidade.Id == id);
            return query.Any() ? query.First() : null;
        }

        public virtual List<TEntidade> ObterTodos()
        {
            var entidades = Context.Set<TEntidade>().ToList();
            return entidades.Any() ? entidades : new List<TEntidade>();
        }
    }
}
