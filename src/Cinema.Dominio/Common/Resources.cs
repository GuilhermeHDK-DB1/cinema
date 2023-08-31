﻿using Cinema.Dominio.Dtos.Sessoes;

namespace Cinema.Dominio.Common
{
    public static class Resources
    {
        public static string NomeInvalido = "Nome inválido";

        public static string GeneroComMesmoNomeJaExiste = "Gênero com mesmo nome já existe";
        public static string SalaComMesmoNomeJaExiste = "Sala com mesmo nome já existe";

        public static string GeneroComIdInexistente = "Não existe gênero com este id";
        public static string FilmeComIdInexistente = "Não existe filme com este id";
        public static string SalaComIdInexistente = "Não existe sala com este id";

        public static string GeneroComNomeInexistente = "Gênero do filme informado não existe";

        public static string ClassificaoIndicativaInvalida = "Classificação indicativa inválida";

        public static string FormatoDeDataInvalida = "Data deve seguir o formato AAAA-MM-DD";

        public static string FormatoDeHorarioInvalido = "Data deve seguir o formato AAAA-MM-DD hh:mm:ss";
    }
}
