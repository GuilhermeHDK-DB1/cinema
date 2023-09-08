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

        public override Sessao ObterPorId(int id)
        {
            var sessao = _context.Set<Sessao>()
                .Include(sessao => sessao.Filme)
                    .ThenInclude(filme => filme.Genero)
                .Include(sessao => sessao.Sala)
                .Include(sessao => sessao.Ingressos)
                .Where(sessao => sessao.Id == id);
            return sessao.Any() ? sessao.First() : null;
        }

        public override List<Sessao> ObterTodos()
        {
            var sessoes = _context.Set<Sessao>()
                .Include(sessao => sessao.Filme)
                    .ThenInclude(filme => filme.Genero)
                .Include(sessao => sessao.Sala)
                .Include(sessao => sessao.Ingressos)
                .ToList();
            return sessoes.Any() ? sessoes : new List<Sessao>();
        }

        public override List<Sessao> ObterPaginado(int skip, int take)
        {
            var sessoes = _context.Set<Sessao>()
                .Include(sessao => sessao.Filme)
                .Include(sessao => sessao.Sala)
                .Skip(skip)
                .Take(take)
                .ToList();
            return sessoes.Any() ? sessoes : new List<Sessao>();
        }

        public Sessao ObterPelaSalaEHorario(int salaId, DateTime horario)
        {
            var sessao = _context.Set<Sessao>()
                .Include(sessao => sessao.Filme)
                    .ThenInclude(filme => filme.Genero)
                .Include(sessao => sessao.Sala)
                .Include(sessao => sessao.Ingressos)
                .Where(sessao => sessao.Sala.Id == salaId &&
                sessao.Horario == horario);
            return sessao.Any() ? sessao.First() : null;
        }

        public IEnumerable<Sessao> ObterSessoesPelaData(DateTime data)
        {
            var sessoes = _context.Set<Sessao>()
                .Include(sessao => sessao.Filme)
                    .ThenInclude(filme => filme.Genero)
                .Include(sessao => sessao.Sala)
                .Include(sessao => sessao.Ingressos)
                .Where(sessao => sessao.Horario.Date == data)
                .ToList();
            return sessoes.Any() ? sessoes : new List<Sessao>();
        }

        public IEnumerable<Sessao> ObterSessoesNaoIniciadasPorFilmeEData(int filmeId, DateTime data)
        {
            var sessoes = _context.Set<Sessao>()
                .Include(sessao => sessao.Filme)
                    .ThenInclude(filme => filme.Genero)
                .Include(sessao => sessao.Sala)
                .Include(sessao => sessao.Ingressos)
                .Where(sessao => 
                    sessao.Horario.Date == data &&
                    sessao.Horario > DateTime.Now.AddMinutes(-15) &&
                    sessao.Filme.Id == filmeId)
                .ToList()
                .OrderBy(sessao => sessao.Horario);
            return sessoes.Any() ? sessoes : new List<Sessao>();
        }

        public IEnumerable<Sessao> ObterSessoesNaoIniciadasPorHorario(DateTime horario)
        {
            var sessoes = _context.Set<Sessao>()
                .Include(sessao => sessao.Filme)
                    .ThenInclude(filme => filme.Genero)
                .Include(sessao => sessao.Sala)
                .Include(sessao => sessao.Ingressos)
                .Where(sessao =>
                    sessao.Horario == horario &&
                    sessao.Horario > DateTime.Now.AddMinutes(-15))
                .ToList()
                .OrderBy(sessao => sessao.Horario);
            return sessoes.Any() ? sessoes : new List<Sessao>();
        }

        public IEnumerable<Sessao> ObterSessoesNaoIniciadasDoDia()
        {
            var sessoes = _context.Set<Sessao>()
                .Include(sessao => sessao.Filme)
                    .ThenInclude(filme => filme.Genero)
                .Include(sessao => sessao.Sala)
                .Include(sessao => sessao.Ingressos)
                .Where(sessao =>
                    sessao.Horario.Date == DateTime.Today &&
                    sessao.Horario > DateTime.Now.AddMinutes(-15))
                .ToList()
                .OrderBy(sessao => sessao.Horario);
            return sessoes.Any() ? sessoes : new List<Sessao>();
        }

        public int ObterCapacidadeDaSalaPeloId(int id)
        {
            var sessao = _context.Set<Sessao>()
                .Include(sessao => sessao.Sala)
                .Where(sessao => sessao.Id == id)
                .Select(sessao => new
                {
                    CapacidadeDaSala = sessao.Sala.Capacidade
                })
                .FirstOrDefault();
            return sessao.CapacidadeDaSala != null ? sessao.CapacidadeDaSala : 0;
        }
    }
}
