using Cinema.Dominio.Consultas;
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
        public IEnumerable<GeneroReadDto> ObterPaginado(
            [FromServices] IGeneroConsulta consulta,
            [FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return consulta.ConsultaPaginadaDeGeneros(skip, take);
        }

        [HttpGet("consultar/{id}")]
        public IActionResult ObterPorId(int id,
            [FromServices] IGeneroConsulta consulta)
        {
            GeneroReadDto generoDto = consulta.ConsultaDeGeneroPorId(id);

            return generoDto is not null ? Ok(generoDto) : NotFound();
        }

        [HttpPost("adicionar")]
        public IActionResult Adicionar([FromBody] CadastrarGeneroCommand generoDto)
        {
            //GeneroReadDto generoResponse =  _manipuladorDeGenero.Adicionar(generoDto);

            //return CreatedAtAction(nameof(ObterPorId), new { id = generoResponse.Id }, generoResponse);

            return Ok(generoDto);
        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar([FromBody] GeneroUpdateDto generoDto)
        {
            GeneroReadDto generoResponse = _manipuladorDeGenero.Atualizar(generoDto);

            return Ok(generoResponse);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            var linhasAfetadas = _manipuladorDeGenero.Excluir(id);

            return linhasAfetadas > 0 ? Ok() : NotFound();
        }
    }
}
