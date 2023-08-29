using Cinema.Dados.Contextos;
using Cinema.Dominio.Entities.Salas;
using Cinema.Dominio.Services;

namespace Cinema.Dados.Repositorio
{
    public class SalaRepositorio : RepositorioBase<Sala>, ISalaRepositorio
    {
        private readonly ApplicationDbContext _context;
        public SalaRepositorio(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Sala ObterPeloNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sala> ObterPorSala3D()
        {
            var entidades = _context.Set<Sala>()
                .Where(entidade => entidade.Sala3D == true)
                .ToList();
            return entidades.Any() ? entidades : new List<Sala>();
        }

        public IEnumerable<Sala> ObterPorSalaVip()
        {
            var entidades = _context.Set<Sala>()
                .Where(entidade => entidade.SalaVip == true)
                .ToList();
            return entidades.Any() ? entidades : new List<Sala>();
        }
    }
}
