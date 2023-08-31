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

            if (Regex.IsMatch(data, regexDeData))
                return true;

            DateTime datetime;

            return DateTime.TryParse(data, out datetime);
        }
    }
}