using Cinema.Dados.Persistence;
using Cinema.Dominio.Entities.Clientes;
using Cinema.Dominio.Services;

namespace Cinema.Dados.Repositorio
{
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {
        protected readonly ApplicationDbContext _context;

        public ClienteRepositorio(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Cliente ObterPeloCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPeloEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
