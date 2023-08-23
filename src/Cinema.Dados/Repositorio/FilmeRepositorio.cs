using Cinema.Dados.Contextos;
using Cinema.Dominio.Entities.Filmes;
using Cinema.Dominio.Services;

namespace Cinema.Dados.Repositorio
{
    public class FilmeRepositorio : IFilmeRepositorio
    {
        private readonly ApplicationDbContext _context;

        public FilmeRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public Filme ObterPorId(int id)
        {
            var filme = _context.Set<Filme>().Where(filme => filme.Id == id);
            return filme.Any() ? filme.First() : null;
        }

        public List<Filme> ObterTodos()
        {
            var filmes = _context.Set<Filme>().ToList();
            return filmes.Any() ? filmes : new List<Filme>();
        }

        public Filme ObterPeloNome(string nome)
        {
            var filme = _context.Set<Filme>().Where(filme => filme.Nome.Contains(nome));
            return filme.Any() ? filme.First() : null;
        }
    }
}
