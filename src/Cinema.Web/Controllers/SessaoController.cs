using Cinema.Dominio.Consultas.Filmes;
using Cinema.Dominio.Consultas.Sessoes;
using Cinema.Dominio.Dtos.Filmes;
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

        [HttpGet("consultar/{id}")]
        public IActionResult ObterPorId(int id,
            [FromServices] ISessaoConsulta consulta)
        {
            ResumoDeSessaoResult sessaoDto = consulta.ConsultaDeSessaoPorId(id);

            return sessaoDto is not null ? Ok(sessaoDto) : BadRequest();
        }

        [HttpGet("consultar-sessoes-da-data")]
        public IEnumerable<ResumoDeSessaoResult> ObterSessoesDaData(
            [FromQuery] ObterSessoesDaDataQuery query,
            [FromServices] ISessaoConsulta consulta)
        {
            return consulta.ConsultaDeSessoesDaData(query.Data);
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
