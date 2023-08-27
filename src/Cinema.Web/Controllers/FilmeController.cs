using Cinema.Dominio.Consultas.Filmes;
using Cinema.Dominio.Consultas.Generos;
using Cinema.Dominio.Dtos.Filmes;
using Cinema.Dominio.Dtos.Generos;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        public FilmeController()
        {
            
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

            return filmeDto is not null ? Ok(filmeDto) : NotFound();
        }

    }
}
