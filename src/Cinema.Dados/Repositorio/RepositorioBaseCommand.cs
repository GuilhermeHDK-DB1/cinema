using Cinema.Dados.Contextos;
using Cinema.Dominio.Common;


namespace Cinema.Dados.Repositorio
{
    public class RepositorioBaseCommand<TEntidade> : IRepositorioCommand<TEntidade> where TEntidade : Entidade
    {
        protected readonly ApplicationDbContext _context;

        public RepositorioBaseCommand(ApplicationDbContext context)
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
    }
}
