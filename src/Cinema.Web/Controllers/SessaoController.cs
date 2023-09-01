using Cinema.Dominio.Consultas.Sessoes;
using Cinema.Dominio.Dtos.Sessoes;
using Cinema.Dominio.Services.Manipuladores;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly ManipuladorDeSessao _manipuladorDeSessao;
        public SessaoController(ManipuladorDeSessao manipuladorDeSessao)
        {
            _manipuladorDeSessao = manipuladorDeSessao;
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
            [FromQuery] ObterSessoesPorFilmeEDataQuery query,
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

        [HttpGet("consultar-sessoes-nao-iniciadas-do-dia")]
        public IEnumerable<ResumoDeSessaoResult> ObterSessoesNaoIniciadasDoDia(
            [FromServices] ISessaoConsulta consulta)
        {
            return consulta.ConsultaDeSessoesNaoIniciadasDoDia();
        }

        [HttpPost("adicionar")]
        public IActionResult Adicionar([FromBody] CadastrarSessaoCommand sessaoDto)
        {
            SessaoResult sessaoResponse = _manipuladorDeSessao.Adicionar(sessaoDto);

            return sessaoResponse is null ? BadRequest()
                : CreatedAtAction(nameof(ObterPorId), new { id = sessaoResponse.Id }, sessaoResponse);
        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar([FromBody] AtualizarSessaoCommand sessaoDto)
        {
            SessaoResult sessaoResponse = _manipuladorDeSessao.Atualizar(sessaoDto);

            return sessaoResponse is null ? BadRequest() : Ok(sessaoResponse);
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir(
            [FromQuery] ExcluirSessaoQuery query)
        {
            var linhasAfetadas = _manipuladorDeSessao.Excluir(query.Id);

            return linhasAfetadas > 0 ? Ok() : BadRequest();
        }
    }
}
