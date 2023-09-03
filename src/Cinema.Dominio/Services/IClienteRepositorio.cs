using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Clientes;

namespace Cinema.Dominio.Services
{
    public interface IClienteRepositorio : IRepositorioBase<Cliente>
    {
        Cliente ObterPeloCpf(string cpf);
        Cliente ObterPeloEmail(string email);
        IEnumerable<Cliente> ObterAtivos();
        void Desativar(Cliente cliente);
        void Ativar(Cliente cliente);
    }
}
