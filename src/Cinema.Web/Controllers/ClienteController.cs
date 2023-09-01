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

        [HttpGet("consultar-por-cpf/{cpf}")]
        public IActionResult ObterPeloCpf(string cpf,
           [FromServices] IClienteConsulta consulta)
        {
            ClienteResult clienteDto = consulta.ConsultaDeFilmePeloCpf(cpf);

            return clienteDto is not null ? Ok(clienteDto) : BadRequest();
        }

        [HttpGet("consultar-por-email/{email}")]
        public IActionResult ObterPeloEmail(string email,
           [FromServices] IClienteConsulta consulta)
        {
            ClienteResult clienteDto = consulta.ConsultaDeFilmePeloEmail(email);

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
