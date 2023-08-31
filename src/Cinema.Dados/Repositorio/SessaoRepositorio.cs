using Cinema.Dados.Persistence;
using Cinema.Dominio.Entities.Sessoes;
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

        public Sessao ObterPorChave(int filmeId, int salaId, DateTime horario)
        {
            throw new NotImplementedException();
        }

        public List<Sessao> ObterPaginado(int skip, int take)
        {
            var entidades = _context.Set<Sessao>()
                .Include(sessao => sessao.Filme)
                .Include(sessao => sessao.Sala)
                .Skip(skip)
                .Take(take)
                .ToList();
            return entidades.Any() ? entidades : new List<Sessao>();
        }

        public List<Sessao> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Adicionar(Sessao entity)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Sessao entity)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Sessao entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sessao> ObterSessoesDoDia(DateTime data)
        {
            var sessoes = _context.Set<Sessao>()
                .Include(sessao => sessao.Filme)
                    .ThenInclude(filme => filme.Genero)
                .Include(sessao => sessao.Sala)
                .Where(sessao => sessao.Horario.Date == data)
                .ToList();
            return sessoes.Any() ? sessoes : new List<Sessao>();
        }
    }
}
