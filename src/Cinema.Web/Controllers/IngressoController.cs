using Cinema.Dominio.Consultas.Ingressos;
using Cinema.Dominio.Dtos.Ingressos;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Web.Controllers
{
    public class IngressoController : ControllerBase
    {
        public IngressoController()
        {
            
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
    }
}
