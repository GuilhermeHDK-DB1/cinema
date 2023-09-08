using Cinema.Dados.Persistence;
using Cinema.Dominio.Entities.Ingressos;
using Cinema.Dominio.Services;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Dados.Repositorio
{
    public class IngressoRepositorio : RepositorioBase<Ingresso>, IIngressoRepositorio
    {
        protected readonly ApplicationDbContext _context;

        public IngressoRepositorio(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override Ingresso ObterPorId(int id)
        {
            var ingresso = _context.Set<Ingresso>()
                .Include(ingresso => ingresso.Cliente)
                .Include(ingresso => ingresso.Sessao)
                    .ThenInclude(sessao => sessao.Filme)
                .Include(ingresso => ingresso.Sessao)
                    .ThenInclude(sessao => sessao.Sala)
                .Where(ingresso => ingresso.Id == id);
            return ingresso.Any() ? ingresso.First() : null;
        }

        public override List<Ingresso> ObterPaginado(int skip, int take)
        {
            var ingressos = _context.Set<Ingresso>()
                .Include(ingresso => ingresso.Cliente)
                .Include(ingresso => ingresso.Sessao)
                .Skip(skip)
                .Take(take)
                .ToList();
            return ingressos.Any() ? ingressos : new List<Ingresso>();
        }

        public IEnumerable<Ingresso> ObterIngressosPeloClienteId(int clienteId)
        {
            var ingressos = _context.Set<Ingresso>()
                .Include(ingresso => ingresso.Cliente)
                .Include(ingresso => ingresso.Sessao)
                    .ThenInclude(sessao => sessao.Filme)
                .Include(ingresso => ingresso.Sessao)
                    .ThenInclude(sessao => sessao.Sala)
                .Where(ingresso => ingresso.Cliente.Id == clienteId)
                .ToList();
            return ingressos.Any() ? ingressos : new List<Ingresso>();
        }

        public IEnumerable<Ingresso> ObterIngressosPeloSessaoId(int sessaoId)
        {
            var ingressos = _context.Set<Ingresso>()
                .Include(ingresso => ingresso.Cliente)
                .Include(ingresso => ingresso.Sessao)
                    .ThenInclude(sessao => sessao.Filme)
                .Include(ingresso => ingresso.Sessao)
                    .ThenInclude(sessao => sessao.Sala)
                .Where(ingresso => ingresso.Sessao.Id == sessaoId)
                .ToList();
            return ingressos.Any() ? ingressos : new List<Ingresso>();
        }

        public int ObterQuantidadeDeIngressosVendidosPeloSessaoId(int sessaoId)
        {
            var quantidadeDeIngressos = _context.Set<Ingresso>()
                .Include(ingresso => ingresso.Sessao)
                .Where(ingresso => ingresso.Sessao.Id == sessaoId)
                .Count();
            return quantidadeDeIngressos;
        }
    }
}
