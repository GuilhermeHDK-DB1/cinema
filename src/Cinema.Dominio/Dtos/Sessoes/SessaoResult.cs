﻿using Cinema.Dominio.Entities.Sessao;

namespace Cinema.Dominio.Dtos.Sessoes
{
    public class SessaoResult
    {
        public int FilmeId { get; set; }
        public int SalaId { get; set; }
        public DateTime Horario { get; set; }
        public Idiomas Idioma { get; set; }
        
        public SessaoResult(FilmeSala sessao)
        {
            FilmeId = sessao.Filme.Id;
            SalaId = sessao.Sala.Id;
            Horario = sessao.Horario;
            Idioma = sessao.Idioma;
        }
    }
}