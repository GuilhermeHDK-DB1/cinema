using Cinema.Dados.Persistence;
using Cinema.Dominio.Entities.Sessao;
using Cinema.Dominio.Services;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Dados.Repositorio
{
    public class SessaoRepositorio : ISessaoRepositorio
    {
        protected readonly ApplicationDbContext _context;

        public SessaoRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public FilmeSala ObterPorChave(int filmeId, int salaId, DateTime horario)
        {
            throw new NotImplementedException();
        }

        public List<FilmeSala> ObterPaginado(int skip, int take)
        {
            var entidades = _context.Set<FilmeSala>()
                .Include(sessao => sessao.Filme)
                .Include(sessao => sessao.Sala)
                .Skip(skip)
                .Take(take)
                .ToList();
            return entidades.Any() ? entidades : new List<FilmeSala>();
        }

        public List<FilmeSala> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Adicionar(FilmeSala entity)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(FilmeSala entity)
        {
            throw new NotImplementedException();
        }

        public void Excluir(FilmeSala entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FilmeSala> ObterSessoesDoDia(DateTime data)
        {
            var sessoes = _context.Set<FilmeSala>()
                .Include(sessao => sessao.Filme)
                    .ThenInclude(filme => filme.Genero)
                .Include(sessao => sessao.Sala)
                .Where(sessao => sessao.Horario.Date == data)
                .ToList();
            return sessoes.Any() ? sessoes : new List<FilmeSala>();
        }
    }
}
