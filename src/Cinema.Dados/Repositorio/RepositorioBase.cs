using Cinema.Dados.Contextos;
using Cinema.Dominio.Common;

namespace Cinema.Dados.Repositorio
{
    public class RepositorioBase<TEntidade>  where TEntidade : Entidade
    {
        protected readonly ApplicationDbContext _context;

        public RepositorioBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Adicionar(TEntidade entity)
        {
            _context.Set<TEntidade>().Add(entity);
        }

        public void Atualizar(TEntidade entity)
        {
            _context.Set<TEntidade>().Update(entity);
        }

        public void Excluir(TEntidade entity)
        {
            _context.Set<TEntidade>().Remove(entity);
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

        public virtual List<TEntidade> ObterPaginado(int skip, int take)
        {
            var entidades = _context.Set<TEntidade>()
                .Skip(skip)
                .Take(take)
                .ToList();
            return entidades.Any() ? entidades : new List<TEntidade>();
        }
    }
}
