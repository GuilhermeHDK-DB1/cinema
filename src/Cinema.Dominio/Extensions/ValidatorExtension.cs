using Cinema.Dominio.Dtos.Sessoes;
using System.Text.RegularExpressions;

namespace Cinema.Dominio.Extensions
{
    public static class ValidatorExtension
    {
        public static bool ValidarClassificacaoIndicativa(string classificacao)
        {
            if (string.IsNullOrEmpty(classificacao))
                return false;

            return ClassificacaoIndicativaExtension.Dicionario.ContainsValue(classificacao);
        }

        public static bool ValidarData(string data)
        {
            if (string.IsNullOrEmpty(data))
                return false;

            string regexDeData = "^\\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$";

            return Regex.IsMatch(data, regexDeData);
        }

        public static bool ValidarHorario(string horario)
        {
            if (string.IsNullOrEmpty(horario))
                return false;

            string regexDeHorario = "^\\d{4}-\\d{2}-\\d{2} \\d{2}:\\d{2}:\\d{2}$";

            return Regex.IsMatch(horario, regexDeHorario);
        }
    }
}