using Cinema.Dados.Contextos;
using Cinema.Dominio.Common;


namespace Cinema.Dados.Repositorio
{
    public class RepositorioBaseQuery<TEntidade> : IRepositorioQuery<TEntidade> where TEntidade : Entidade
    {
        protected readonly ApplicationDbContext _context;

        public RepositorioBaseQuery(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual TEntidade ObterPorId(int id)
        {
            var query = _context.Set<TEntidade>().Where(entidade => entidade.Id == id);
            return query.Any() ? query.First() : null;
        }

        public virtual List<TEntidade> ObterTodos()
        {
            var entidades = _context.Set<TEntidade>().ToList();
            return entidades.Any() ? entidades : new List<TEntidade>();
        }
    }
}
