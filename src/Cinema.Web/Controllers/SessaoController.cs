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

        [HttpGet("consultar/{id}")]
        public IActionResult ObterPorId(int id,
            [FromServices] ISessaoConsulta consulta)
        {
            ResumoDeSessaoResult sessaoDto = consulta.ConsultaDeSessaoPorId(id);

            return sessaoDto is not null ? Ok(sessaoDto) : BadRequest();
        }

        [HttpGet("consultar-sessoes-pela-data")]
        public IEnumerable<ResumoDeSessaoResult> ObterSessoesPelaData(
            [FromQuery] ObterSessoesPelaDataQuery query,
            [FromServices] ISessaoConsulta consulta)
        {
            return consulta.ConsultaDeSessoesPelaData(query.Data);
        }

        [HttpGet("consultar-sessoes-nao-iniciadas-por-filme-e-data")]
        public IEnumerable<ResumoDeSessaoResult> ObterSessoesNaoIniciadasPorFilmeEData(
            [FromQuery] ObterSessoesPorDiaEDataQuery query,
            [FromServices] ISessaoConsulta consulta)
        {
            return consulta.ConsultaDeSessoesNaoIniciadasPorFilmeEData(query.FilmeId, query.Data);
        }

        [HttpGet("consultar-sessoes-nao-iniciadas-por-horario")]
        public IEnumerable<ResumoDeSessaoResult> ObterSessoesNaoIniciadasPorHorario(
            [FromQuery] ObterSessoesPorHorarioQuery query,
            [FromServices] ISessaoConsulta consulta)
        {
            return consulta.ConsultaDeSessoesNaoIniciadasPorHorario(query.Horario);
        }
    }
}
