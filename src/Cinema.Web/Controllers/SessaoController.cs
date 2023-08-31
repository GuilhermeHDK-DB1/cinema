using Cinema.Dominio.Consultas.Sessoes;
using Cinema.Dominio.Dtos.Sessoes;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        public SessaoController()
        {
            
        }

        [HttpGet("consultar")]
        public IEnumerable<SessaoResult> ObterPaginado(
            [FromServices] ISessaoConsulta consulta,
            [FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return consulta.ConsultaPaginadaDeSessoes(skip, take);
        }

        [HttpGet("consultar-sessoes-do-dia")]
        public IEnumerable<ResumoDeSessaoResult> ObterSessoesDoDoDia(
            [FromQuery] ObterSessoesDoDoDiaQuery query,
            [FromServices] ISessaoConsulta consulta)
        {
            return consulta.ConsultaDeSessoesDoDia(query.Data);
        }

        //[HttpGet("consultar/{id}")]
        //public IActionResult ObterPorId(int id,
        //    [FromServices] IFilmeConsulta consulta)
        //{
        //    FilmeResult filmeDto = consulta.ConsultaDeFilmePorId(id);

        //    return filmeDto is not null ? Ok(filmeDto) : BadRequest();
        //}
    }
}
