using Cinema.Dominio.Consultas.Filmes;
using Cinema.Dominio.Dtos.Filmes;
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

        [HttpGet("consultar/{id}")]
        public IActionResult ObterPorId(int id,
            [FromServices] IFilmeConsulta filmeConsulta)
        {
            FilmeResult filmeDto = filmeConsulta.ConsultaDeFilmePorId(id);

            return filmeDto is not null ? Ok(filmeDto) : NotFound();
        }

    }
}
