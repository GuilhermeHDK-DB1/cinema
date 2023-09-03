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
            var cliente = _context.Set<Cliente>().Where(cliente => cliente.Cpf == cpf);
            return cliente.Any() ? cliente.First() : null;
        }

        public Cliente ObterPeloEmail(string email)
        {
            var cliente = _context.Set<Cliente>().Where(cliente => cliente.Email == email);
            return cliente.Any() ? cliente.First() : null;
        }

        public IEnumerable<Cliente> ObterAtivos()
        {
            var clientes = _context.Set<Cliente>().Where(cliente => cliente.Ativo == true).ToList();
            return clientes.Any() ? clientes : new List<Cliente>();
        }

        public void Desativar(Cliente cliente)
        {
            cliente.Ativo = false;
        }
    }
}
