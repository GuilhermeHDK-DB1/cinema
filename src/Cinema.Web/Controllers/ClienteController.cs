using Cinema.Dominio.Consultas.Cliente;
using Cinema.Dominio.Dtos.Clientes;
using Cinema.Dominio.Services.Manipuladores;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private ManipuladorDeCliente _manipuladorDeCliente;

        public ClienteController(ManipuladorDeCliente manipuladorDeCliente)
        {
            _manipuladorDeCliente = manipuladorDeCliente;
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

        [HttpPost("adicionar")]
        public IActionResult Adicionar([FromBody] CadastrarClienteCommand clienteDto)
        {
            ClienteResult clienteResponse = _manipuladorDeCliente.Adicionar(clienteDto);

            return clienteResponse is null ? BadRequest()
                : CreatedAtAction(nameof(ObterPorId), new { id = clienteResponse.Id }, clienteResponse);
        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar([FromBody] AtualizarClienteCommand clienteDto)
        {
            ClienteResult clienteResponse = _manipuladorDeCliente.Atualizar(clienteDto);

            return clienteResponse is null ? BadRequest() : Ok(clienteResponse);
        }
    }
}
