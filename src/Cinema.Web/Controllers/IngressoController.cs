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
    }
}
