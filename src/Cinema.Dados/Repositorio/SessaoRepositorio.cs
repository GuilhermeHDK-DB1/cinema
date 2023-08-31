using Cinema.Dados.Persistence;
using Cinema.Dominio.Entities.Sessoes;
using Cinema.Dominio.Services;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Dados.Repositorio
{
    public class SessaoRepositorio : RepositorioBase<Sessao>, ISessaoRepositorio
    {
        protected readonly ApplicationDbContext _context;

        public SessaoRepositorio(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Sessao ObterPorId(int id)
        {
            var sessao = _context.Set<Sessao>()
                .Include(sessao => sessao.Filme)
                    .ThenInclude(filme => filme.Genero)
                .Include(sessao => sessao.Sala)
                .Include(sessao => sessao.SessoesIngressos)
                .Where(sessao => sessao.Id == id);
            return sessao.Any() ? sessao.First() : null;
        }

        public List<Sessao> ObterPaginado(int skip, int take)
        {
            var sessoes = _context.Set<Sessao>()
                .Include(sessao => sessao.Filme)
                .Include(sessao => sessao.Sala)
                .Skip(skip)
                .Take(take)
                .ToList();
            return sessoes.Any() ? sessoes : new List<Sessao>();
        }

        public IEnumerable<Sessao> ObterSessoesDoDia(DateTime data)
        {
            var sessoes = _context.Set<Sessao>()
                .Include(sessao => sessao.Filme)
                    .ThenInclude(filme => filme.Genero)
                .Include(sessao => sessao.Sala)
                .Include(sessao => sessao.SessoesIngressos)
                .Where(sessao => sessao.Horario.Date == data)
                .ToList();
            return sessoes.Any() ? sessoes : new List<Sessao>();
        }

        public List<Sessao> ObterTodos()
        {
            var sessoes = _context.Set<Sessao>()
                .Include(sessao => sessao.Filme)
                    .ThenInclude(filme => filme.Genero)
                .Include(sessao => sessao.Sala)
                .Include(sessao => sessao.SessoesIngressos)
                .ToList();
            return sessoes.Any() ? sessoes : new List<Sessao>();
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

        
    }
}
