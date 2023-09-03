namespace Cinema.Dominio.Common
{
    public static class Resources
    {
        public static string NomeInvalido = "Nome inválido";

        public static string GeneroComMesmoNomeJaExiste = "Gênero com mesmo nome já existe";
        public static string SalaComMesmoNomeJaExiste = "Sala com mesmo nome já existe";
        public static string SessaoComMesmosDadosJaExiste = "Sessão com mesmos dados já existe";
        public static string ClienteComMesmoCpfJaExiste = "Cliente com mesmo CPF já existe";
        public static string ClienteComMesmoEmailJaExiste = "Cliente com mesmo Email já existe";

        public static string GeneroComIdInexistente = "Não existe gênero com este id";
        public static string FilmeComIdInexistente = "Não existe filme com este id";
        public static string SalaComIdInexistente = "Não existe sala com este id";
        public static string SessaoComIdInexistente = "Não existe sessao com este id";
        public static string ClienteComIdInexistente = "Não existe cliente com este id";

        public static string GeneroComNomeInexistente = "Gênero do filme informado não existe";

        public static string ClassificaoIndicativaInvalida = "Classificação indicativa inválida";
        public static string IdiomaInvalido = "Idioma inválido";

        public static string FormatoDeDataInvalida = "Data deve seguir o formato AAAA-MM-DD";

        public static string FormatoDeHorarioInvalido = "Horário deve seguir o formato AAAA-MM-DD hh:mm:ss";
        public static string HorarioNaoPermitido = "Horários permitidos: 10:00:00, 13:00:00, 16:00:00, 19:00:00, 22:00:00";

        public static string FormatoDeCpfInvalido = "CPF deve seguir o formato 11122233344";
        public static string FormatoDeEmailInvalido = "Email nulo ou inválido";

        internal static string ClienteJaEstaInativo = "Cliente já está inativo";
        internal static string ClienteJaEstaAtivo = "Cliente já está ativo";
    }
}
