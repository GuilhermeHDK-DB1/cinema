using Cinema.Dados.Contextos;
using Cinema.Dominio.Entities.Filmes;
using Cinema.Dominio.Services;

namespace Cinema.Dados.Repositorio
{
    public class FilmeRepositorio : RepositorioBase<Filme>, IFilmeRepositorio
    {
        private readonly ApplicationDbContext _context;

        public FilmeRepositorio(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Filme ObterPeloNome(string nome)
        {
            var filme = _context.Set<Filme>().Where(filme => filme.Nome.Contains(nome));
            return filme.Any() ? filme.First() : null;
        }
    }
}
