using Cinema.Dominio.Consultas.Generos;
using Cinema.Dominio.Dtos.Generos;
using Cinema.Dominio.Services.Manipuladores;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneroController : ControllerBase
    {
        private readonly ManipuladorDeGenero _manipuladorDeGenero;

        public GeneroController(ManipuladorDeGenero manipuladorDeGenero)
        {
            _manipuladorDeGenero = manipuladorDeGenero;
        }

        [HttpGet("consultar")]
        public IEnumerable<GeneroResult> ObterPaginado(
            [FromServices] IGeneroConsulta consulta,
            [FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return consulta.ConsultaPaginadaDeGeneros(skip, take);
        }

        [HttpGet("consultar/{id}")]
        public IActionResult ObterPorId(int id,
            [FromServices] IGeneroConsulta consulta)
        {
            GeneroResult generoDto = consulta.ConsultaDeGeneroPorId(id);

            return generoDto is not null ? Ok(generoDto) : NotFound();
        }

        [HttpPost("adicionar")]
        public IActionResult Adicionar([FromBody] CadastrarGeneroCommand generoDto)
        {
            GeneroResult generoResponse = _manipuladorDeGenero.Adicionar(generoDto);

            return generoResponse is null ? BadRequest() :
                CreatedAtAction(nameof(ObterPorId), new { id = generoResponse.Id }, generoResponse);
        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar([FromBody] AtualizarGeneroCommand generoDto)
        {
            GeneroResult generoResponse = _manipuladorDeGenero.Atualizar(generoDto);

            return generoResponse is null ? BadRequest() : Ok(generoResponse);
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir(
            [FromQuery] ExcluirGeneroQuery query)
        {
            var linhasAfetadas = _manipuladorDeGenero.Excluir(query.Id);

            return linhasAfetadas > 0 ? Ok() : NotFound();
        }
    }
}
