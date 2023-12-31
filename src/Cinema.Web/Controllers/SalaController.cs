﻿using Cinema.Dominio.Consultas.Salas;
using Cinema.Dominio.Dtos.Salas;
using Cinema.Dominio.Services.Manipuladores;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaController : ControllerBase
    {
        private readonly ManipuladorDeSala _manipuladorDeSala;

        public SalaController(ManipuladorDeSala manipuladorDeSala)
        {
            _manipuladorDeSala = manipuladorDeSala;
        }

        [HttpGet("consultar")]
        public IEnumerable<SalaResult> ObterPaginado(
            [FromServices] ISalaConsulta consulta,
            [FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            return consulta.ConsultaPaginadaDeSalas(skip, take);
        }

        [HttpGet("consultar/{id}")]
        public IActionResult ObterPorId(int id,
            [FromServices] ISalaConsulta consulta)
        {
            SalaResult salaDto = consulta.ConsultaDeSalaPorId(id);

            return salaDto is not null ? Ok(salaDto) : BadRequest();
        }

        [HttpGet("consultar-por-salavip")]
        public IEnumerable<SalaResult> ObterPorSalaVip(
            [FromServices] ISalaConsulta consulta)
        {
            return consulta.ConsultaDeSalasVip();
        }

        [HttpGet("consultar-por-sala3d")]
        public IEnumerable<SalaResult> ObterPorSala3D(
            [FromServices] ISalaConsulta consulta)
        {
            return consulta.ConsultaDeSalas3D();
        }

        [HttpPost("adicionar")]
        public IActionResult Adicionar([FromBody] CadastrarSalaCommand salaDto)
        {
            SalaResult salaeResponse = _manipuladorDeSala.adicionar(salaDto);

            return salaeResponse is null ? BadRequest()
                : CreatedAtAction(nameof(ObterPorId), new { id = salaeResponse.Id }, salaeResponse);
        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar([FromBody] AtualizarSalaCommand salaDto)
        {
            SalaResult salaResponse = _manipuladorDeSala.Atualizar(salaDto);

            return salaResponse is null ? BadRequest() : Ok(salaResponse);
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir(
            [FromQuery] ExcluirSalaQuery query)
        {
            var linhasAfetadas = _manipuladorDeSala.Excluir(query.Id);

            return linhasAfetadas > 0 ? Ok() : BadRequest();
        }
    }
}
