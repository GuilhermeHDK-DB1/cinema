using Cinema.Dados.Contextos;
using Cinema.Dominio.Entities.Generos;
using Cinema.Dominio.Services;

namespace Cinema.Dados.Repositorio
{
    public class GeneroRepositorio : IGeneroRepositorio
    {
        protected readonly ApplicationDbContext _context;

        public GeneroRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Genero genero)
        {
            _context.Set<Genero>().Add(genero);
            _context.SaveChanges();
        }

        public void Atualizar(Genero genero)
        {
            _context.Set<Genero>().Update(genero);
            _context.SaveChanges();
        }

        public void Excluir(Genero genero)
        {
            _context.Set<Genero>().Remove(genero);
            _context.SaveChanges();
        }

        public Genero ObterPorId(int id)
        {
            var query = _context.Set<Genero>().Where(genero => genero.Id == id);
            return query.Any() ? query.First() : null;
        }

        public List<Genero> ObterTodos()
        {
            var generos = _context.Set<Genero>().ToList();
            return generos.Any() ? generos : new List<Genero>();
        }

        public Genero ObterPeloNome(string nome)
        {
            var genero = _context.Set<Genero>().Where(c => c.Nome.Contains(nome));
            return genero.Any() ? genero.First() : null;
        }
    }
}
