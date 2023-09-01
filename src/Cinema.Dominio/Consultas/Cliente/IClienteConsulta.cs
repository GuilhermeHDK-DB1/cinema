using Cinema.Dominio.Dtos.Clientes;

namespace Cinema.Dominio.Consultas.Cliente
{
    public interface IClienteConsulta
    {
        ClienteResult ConsultaDeFilmePorId(int id);
        IEnumerable<ClienteResult> ConsultaPaginadaDeClientes(int skip, int take);
    }
}
