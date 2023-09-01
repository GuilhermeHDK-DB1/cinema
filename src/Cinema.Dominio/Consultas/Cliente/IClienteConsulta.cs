using Cinema.Dominio.Dtos.Clientes;

namespace Cinema.Dominio.Consultas.Cliente
{
    public interface IClienteConsulta
    {
        IEnumerable<ClienteResult> ConsultaPaginadaDeClientes(int skip, int take);
    }
}
