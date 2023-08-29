using Cinema.Dados.Persistence;
using Cinema.Dominio.Entities.Generos;
using Cinema.Dominio.Services;

namespace Cinema.Dados.Repositorio
{
    public class GeneroRepositorio : RepositorioBase<Genero> , IGeneroRepositorio
    {
        protected readonly ApplicationDbContext _context;

        public GeneroRepositorio(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Genero ObterPeloNome(string nome)
        {
            var genero = _context.Set<Genero>().Where(c => c.Nome.Contains(nome));
            return genero.Any() ? genero.First() : null;
        }
    }
}
