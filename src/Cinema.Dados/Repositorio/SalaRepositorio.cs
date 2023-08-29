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
            var sala = _context.Set<Sala>().Where(entidade => entidade.Nome.Contains(nome));
            return sala.Any() ? sala.First() : null;
        }

        public IEnumerable<Sala> ObterPorSala3D()
        {
            var salas = _context.Set<Sala>()
                .Where(sala => sala.Sala3D == true)
                .ToList();
            return salas.Any() ? salas : new List<Sala>();
        }

        public IEnumerable<Sala> ObterPorSalaVip()
        {
            var salas = _context.Set<Sala>()
                .Where(sala => sala.SalaVip == true)
                .ToList();
            return salas.Any() ? salas : new List<Sala>();
        }
    }
}
