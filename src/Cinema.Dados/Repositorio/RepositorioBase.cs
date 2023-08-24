using Cinema.Dados.Contextos;
using Cinema.Dominio.Common;

namespace Cinema.Dados.Repositorio
{
    public class RepositorioBase<TEntidade>  where TEntidade : Entidade
    {/*IRepositorioBase<TEntidade>*/
        protected readonly ApplicationDbContext _context;

        public RepositorioBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Adicionar(TEntidade entity)
        {
            _context.Set<TEntidade>().Add(entity);
            _context.SaveChanges();
        }

        public void Atualizar(TEntidade entity)
        {
            _context.Set<TEntidade>().Update(entity);
            _context.SaveChanges();
        }

        public void Excluir(TEntidade entity)
        {
            _context.Set<TEntidade>().Remove(entity);
            _context.SaveChanges();
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
