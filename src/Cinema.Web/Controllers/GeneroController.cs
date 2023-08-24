using Cinema.Dominio.Consultas;
using Cinema.Dominio.Dtos.Generos;
using Cinema.Dominio.Services;
using Cinema.Dominio.Services.Handlers;
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

        [HttpGet]
        public IEnumerable<GeneroReadDto> ObterPaginado(
            [FromServices] IGeneroConsulta consulta,
            [FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return consulta.ConsultaPaginadaDeGeneros(skip, take);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id,
            [FromServices] IGeneroConsulta consulta)
        {
            GeneroReadDto generoDto = consulta.ConsultaDeGeneroPorId(id);

            return generoDto is not null ? Ok(generoDto) : NotFound();
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] GeneroCreateDto generoDto)
        {
            GeneroReadDto generoResponse =  _manipuladorDeGenero.Adicionar(generoDto);

            return CreatedAtAction(nameof(ObterPorId), new { id = generoResponse.Id }, generoResponse);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] GeneroUpdateDto generoDto)
        {
            GeneroReadDto generoResponse = _manipuladorDeGenero.Atualizar(generoDto);

            return Ok(generoResponse);
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var linhasAfetadas = _manipuladorDeGenero.Excluir(id);

            return linhasAfetadas > 0 ? Ok() : NotFound();
        }
    }
}
