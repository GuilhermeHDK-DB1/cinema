using Cinema.Dominio.Consultas.Ingressos;
using Cinema.Dominio.Dtos.Ingressos;
using Cinema.Dominio.Services.Manipuladores;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Web.Controllers
{
    public class IngressoController : ControllerBase
    {
        private readonly ManipuladorDeIngresso _manipuladorDeIngresso;

        public IngressoController(ManipuladorDeIngresso manipuladorDeIngresso)
        {
            _manipuladorDeIngresso = manipuladorDeIngresso;
        }

        [HttpGet("consultar")]
        public IEnumerable<IngressoResult> ObterPaginado(
            [FromServices] IIngressoConsulta consulta,
            [FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return consulta.ConsultaPaginadaDeIngressos(skip, take);
        }

        [HttpGet("consultar/{id}")]
        public IActionResult ObterPorId(int id,
            [FromServices] IIngressoConsulta consulta)
        {
            ResumoDeIngressoResult ingressoDto = consulta.ConsultaDeIngressoPorId(id);

            return ingressoDto is not null ? Ok(ingressoDto) : BadRequest();
        }

        [HttpGet("consultar-ingressos-pelo-clienteId")]
        public IEnumerable<ResumoDeIngressoResult> ObterIngressosPeloClienteId(
            [FromQuery] ObterIngressosPeloClienteIdQuery query,
            [FromServices] IIngressoConsulta consulta)
        {
            return consulta.ConsultaDeIngressosPeloClienteId(query.ClienteId);
        }

        [HttpGet("consultar-ingressos-pelo-sessaoId")]
        public IEnumerable<ResumoDeIngressoResult> ObterIngressosPeloSessaoId(
            [FromQuery] ObterIngressosPeloSessaoIdQuery query,
            [FromServices] IIngressoConsulta consulta)
        {
            return consulta.ConsultaDeIngressosPeloSessaoId(query.SessaoId);
        }

        [HttpGet("consultar-quantidade-de-ingressos-vendidos-pelo-sessaoId/{sessaoId}")]
        public IActionResult ObterQuantidadeDeIngressosVendidosPeloSessaoId(int sessaoId,
            [FromServices] IIngressoConsulta consulta)
        {
            QuantidadeDeIngressoResult ingressoDto = consulta.ConsultaDeQuantidadeDeIngressosVendidosPeloSessaoId(sessaoId);

            return ingressoDto is not null ? Ok(ingressoDto) : BadRequest();
        }

        [HttpPost("adicionar")]
        public IActionResult Adicionar([FromBody] CadastrarIngressoCommand ingressooDto)
        {
            IngressoResult ingressoResponse = _manipuladorDeIngresso.Adicionar(ingressooDto);

            return ingressoResponse is null ? BadRequest()
                : CreatedAtAction(nameof(ObterPorId), new { id = ingressoResponse.Id }, ingressoResponse);
        }

        //[HttpPut("atualizar")]
        //public IActionResult Atualizar([FromBody] AtualizarSessaoCommand sessaoDto)
        //{
        //    SessaoResult sessaoResponse = _manipuladorDeSessao.Atualizar(sessaoDto);

        //    return sessaoResponse is null ? BadRequest() : Ok(sessaoResponse);
        //}

        //[HttpDelete("excluir")]
        //public IActionResult Excluir(
        //    [FromQuery] ExcluirSessaoQuery query)
        //{
        //    var linhasAfetadas = _manipuladorDeSessao.Excluir(query.Id);

        //    return linhasAfetadas > 0 ? Ok() : BadRequest();
        //}
    }
}
