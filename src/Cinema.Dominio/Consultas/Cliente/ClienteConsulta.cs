using Cinema.Dominio.Dtos.Clientes;
using Cinema.Dominio.Services;

namespace Cinema.Dominio.Consultas.Cliente
{
    public class ClienteConsulta : IClienteConsulta
    {
        IClienteRepositorio _clienteRepositorio;

        public ClienteConsulta(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public ClienteResult ConsultaDeFilmePorId(int id)
        {
            var cliente = _clienteRepositorio.ObterPorId(id);

            return cliente is not null ? new ClienteResult(cliente) : null;
        }

        public IEnumerable<ClienteResult> ConsultaPaginadaDeClientes(int skip, int take)
        {
            var listaDeClientesResponse = new List<ClienteResult>();

            var clientes = _clienteRepositorio.ObterPaginado(skip, take);

            foreach (var cliente in clientes)
                listaDeClientesResponse.Add(new ClienteResult(cliente));

            return listaDeClientesResponse;
        }
    }
}
