using Cinema.Dados.Contextos;
using Cinema.Dominio.Entities.Generos;
using Cinema.Dominio.Services;

namespace Cinema.Dados.Repositorio
{
    public class GeneroRepositorio : IGeneroRepositorio
    {
        protected readonly ApplicationDbContext Context;

        public GeneroRepositorio(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Adicionar(Genero genero)
        {
            Context.Set<Genero>().Add(genero);
            Context.SaveChanges();
        }

        public void Atualizar(Genero genero)
        {
            Context.Set<Genero>().Update(genero);
            Context.SaveChanges();
        }

        public void Excluir(Genero genero)
        {
            Context.Set<Genero>().Remove(genero);
            Context.SaveChanges();
        }

        public Genero ObterPorId(int id)
        {
            var query = Context.Set<Genero>().Where(genero => genero.Id == id);
            return query.Any() ? query.First() : null;
        }

        public List<Genero> ObterTodos()
        {
            var generos = Context.Set<Genero>().ToList();
            return generos.Any() ? generos : new List<Genero>();
        }

        public Genero ObterPeloNome(string nome)
        {
            var genero = Context.Set<Genero>().Where(c => c.Nome.Contains(nome));
            return genero.Any() ? genero.First() : null;
        }
    }
}
