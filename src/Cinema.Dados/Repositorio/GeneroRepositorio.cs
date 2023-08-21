using Cinema.Dados.Contextos;
using Cinema.Dominio.Entities.Generos;
using Cinema.Dominio.Services;

namespace Cinema.Dados.Repositorio
{
    public class GeneroRepositorio : RepositorioBase<Genero>, IGeneroRepositorio
    {
        public GeneroRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public Genero ObterPeloNome(string nome)
        {
            var entidade = Context.Set<Genero>().Where(c => c.Nome.Contains(nome));
            if (entidade.Any())
                return entidade.First();
            return null;
        }
    }
}
