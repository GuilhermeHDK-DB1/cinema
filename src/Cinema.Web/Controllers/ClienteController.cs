using Cinema.Dominio.Consultas.Cliente;
using Cinema.Dominio.Dtos.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        public ClienteController()
        {
            
        }

        [HttpGet("consultar")]
        public IEnumerable<ClienteResult> ObterPaginado(
            [FromServices] IClienteConsulta consulta,
            [FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return consulta.ConsultaPaginadaDeClientes(skip, take);
        }

        [HttpGet("consultar/{id}")]
        public IActionResult ObterPorId(int id,
           [FromServices] IClienteConsulta consulta)
        {
            ClienteResult clienteDto = consulta.ConsultaDeFilmePorId(id);

            return clienteDto is not null ? Ok(clienteDto) : BadRequest();
        }

        [HttpGet("consultar-por-cpf")]
        public IActionResult ObterPeloCpf(
            [FromQuery] ObterPeloCpfQuery query,
            [FromServices] IClienteConsulta consulta)
        {
            ClienteResult clienteDto = consulta.ConsultaDeFilmePeloCpf(query.Cpf);

            return clienteDto is not null ? Ok(clienteDto) : BadRequest();
        }

        [HttpGet("consultar-por-email")]
        public IActionResult ObterPeloEmail(
            [FromQuery] ObterPeloEmailQuery query,
            [FromServices] IClienteConsulta consulta)
        {
            ClienteResult clienteDto = consulta.ConsultaDeFilmePeloEmail(query.Email);

            return clienteDto is not null ? Ok(clienteDto) : BadRequest();
        }

        [HttpGet("consultar-ativos")]
        public IEnumerable<ClienteResult> ObterAtivos(
            [FromServices] IClienteConsulta consulta)
        {
            return consulta.ConsultaDeClientesAtivos();
        }
    }
}
