using Cinema.Dominio.Consultas.Salas;
using Cinema.Dominio.Dtos.Salas;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaController : ControllerBase
    {
        public SalaController()
        {
            
        }

        [HttpGet("consultar")]
        public IEnumerable<SalaResult> ObterPaginado(
            [FromServices] ISalaConsulta consulta,
            [FromQuery] int skip = 0, [FromQuery] int take = 5)
        {
            return consulta.ConsultaPaginadaDeSalas(skip, take);
        }

        [HttpGet("consultar/{id}")]
        public IActionResult ObterPorId(int id,
            [FromServices] ISalaConsulta consulta)
        {
            SalaResult salaDto = consulta.ConsultaDeSalaPorId(id);

            return salaDto is not null ? Ok(salaDto) : BadRequest();
        }

        [HttpGet("consultar-por-sala3d")]
        public IEnumerable<SalaResult> ObterPorGenero(
            [FromServices] ISalaConsulta consulta)
        {
            return consulta.ConsultaDeSalas3D();
        }
    }
}
