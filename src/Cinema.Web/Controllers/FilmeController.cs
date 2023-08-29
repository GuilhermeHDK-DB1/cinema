using Cinema.Dominio.Consultas.Filmes;
using Cinema.Dominio.Dtos.Filmes;
using Cinema.Dominio.Services.Manipuladores;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly ManipuladorDeFilme _manipuladorDeFilme;

        public FilmeController(ManipuladorDeFilme manipuladorDeFilme)
        {
            _manipuladorDeFilme = manipuladorDeFilme;
        }

        [HttpGet("consultar")]
        public IEnumerable<FilmeResult> ObterPaginado(
            [FromServices] IFilmeConsulta consulta,
            [FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return consulta.ConsultaPaginadaDeFilmes(skip, take);
        }

        [HttpGet("consultar/{id}")]
        public IActionResult ObterPorId(int id,
            [FromServices] IFilmeConsulta consulta)
        {
            FilmeResult filmeDto = consulta.ConsultaDeFilmePorId(id);

            return filmeDto is not null ? Ok(filmeDto) : BadRequest();
        }

        [HttpGet("consultar-por-genero/{genero}")]
        public IEnumerable<FilmeResult> ObterPorGenero(
            string genero,
            [FromServices] IFilmeConsulta consulta)
        {
            return consulta.ConsultaDeFilmesPorGenero(genero);
        }

        [HttpGet("consultar-por-classificacao/{classificacao}")]
        public IEnumerable<FilmeResult> ObterPorClassificacao(
            string classificacao,
            [FromServices] IFilmeConsulta consulta)
        {
            return consulta.ConsultaDeFilmesPorClassificacao(classificacao);
        }

        [HttpPost("adicionar")]
        public IActionResult Adicionar([FromBody] CadastrarFilmeCommand filmeDto)
        {
            FilmeResult filmeResponse = _manipuladorDeFilme.Adicionar(filmeDto);

            return filmeResponse is null ? BadRequest() 
                : CreatedAtAction(nameof(ObterPorId), new { id = filmeResponse.Id }, filmeResponse);
        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar([FromBody] AtualizarFilmeCommand filmeDto)
        {
            FilmeResult filmeResponse = _manipuladorDeFilme.Atualizar(filmeDto);

            return filmeResponse is null ? BadRequest() : Ok(filmeResponse);
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir(
            [FromQuery] ExcluirFilmeQuery query)
        {
            var linhasAfetadas = _manipuladorDeFilme.Excluir(query.Id);

            return linhasAfetadas > 0 ? Ok() : BadRequest();
        }
    }
}
