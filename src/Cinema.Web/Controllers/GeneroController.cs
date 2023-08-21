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
        private readonly IGeneroRepositorio _generoRepositorio;

        public GeneroController(ManipuladorDeGenero manipuladorDeGenero, IGeneroRepositorio generoRepositorio)
        {
            _manipuladorDeGenero = manipuladorDeGenero;
            _generoRepositorio = generoRepositorio;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] GeneroCreateDto generoDto)
        {
            GeneroReadDto generoResponse =  _manipuladorDeGenero.Adicionar(generoDto);

            return CreatedAtAction(nameof(ObterPorId),
                new { id = generoResponse.Id },
                generoResponse);
        }

        [HttpGet]
        public IEnumerable<GeneroReadDto> ObterPaginado([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            var generos = _generoRepositorio.ObterTodos();

            var listaDeGenerosResponse = new List<GeneroReadDto>();
            foreach (var genero in generos)
                listaDeGenerosResponse.Add(new GeneroReadDto(genero));

            return listaDeGenerosResponse.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var genero = _generoRepositorio.ObterPorId(id);
            if (genero == null) return NotFound();

            GeneroReadDto generoResponse = new GeneroReadDto(genero);
            return Ok(generoResponse);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] GeneroUpdateDto generoDto)
        {
            var genero = _generoRepositorio.ObterPorId(id);
            if (genero == null) return NotFound();

            GeneroReadDto generoResponse = _manipuladorDeGenero.Atualizar(id, generoDto);

            return Ok(generoResponse);
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var genero = _generoRepositorio.ObterPorId(id);
            if (genero == null) return NotFound();

            _generoRepositorio.Excluir(genero);
            return NoContent();
        }
    }
}
