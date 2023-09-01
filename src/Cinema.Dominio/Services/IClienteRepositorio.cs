using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Clientes;
using Cinema.Dominio.Entities.Filmes;
using System.ComponentModel;

namespace Cinema.Dominio.Services
{
    public interface IClienteRepositorio : IRepositorioBase<Cliente>
    {
        Cliente ObterPeloCpf(string cpf);
        Cliente ObterPeloEmail(string email);
    }
}
