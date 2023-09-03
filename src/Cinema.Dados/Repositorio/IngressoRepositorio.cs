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
    }
}
