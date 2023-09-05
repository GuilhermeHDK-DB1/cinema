using Cinema.Dominio.Dtos.Ingressos;
using Cinema.Dominio.Entities.Ingressos;
using Cinema.Dominio.Entities.Sessoes;
using System.Text.RegularExpressions;

namespace Cinema.Dominio.Extensions
{
    public static class ValidatorExtension
    {
        private static readonly string _regexDeData = "^\\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$";
        private static string _regexDeHorario = "^\\d{4}-\\d{2}-\\d{2} \\d{2}:\\d{2}:\\d{2}$";
        private static string _regexDeCpf = "^\\d{11}$";
        private static string _regexDeEmail = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";

        private static IEnumerable<TimeSpan> _horariosPermitidos = new List<TimeSpan>
        {
            new TimeSpan(10, 0, 0),
            new TimeSpan(13, 0, 0),
            new TimeSpan(16, 0, 0),
            new TimeSpan(19, 0, 0),
            new TimeSpan(22, 0, 0)
        };

        public static bool ValidarClassificacaoIndicativa(string classificacao)
        {
            if (string.IsNullOrEmpty(classificacao)) return false;

            return ClassificacaoIndicativaExtension.Dicionario.ContainsValue(classificacao);
        }

        public static bool ValidarData(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;

            return Regex.IsMatch(data, _regexDeData);
        }

        public static bool ValidarHorario(string horario)
        {
            if (string.IsNullOrEmpty(horario)) return false;

            return Regex.IsMatch(horario, _regexDeHorario);
        }

        public static bool ValidarHorarioPermitido(string horarioString)
        {
            DateTime.TryParse(horarioString, out DateTime horario);

            return _horariosPermitidos.Any(horarioPermitido => 
                horarioPermitido.Hours.Equals(horario.Hour) &&
                horarioPermitido.Minutes.Equals(horario.Minute) &&
                horarioPermitido.Seconds.Equals(horario.Second));
        }

        public static bool ValidarIdiomas(Idiomas idioma)
        {
            return Enum.IsDefined(typeof(Idiomas), idioma);
        }

        public static bool ValidarTipoDeIngresso(TipoDeIngresso tipo)
        {
            return Enum.IsDefined(typeof(TipoDeIngresso), tipo);
        }

        public static bool ValidarCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;
            
            if (!Regex.IsMatch(cpf, _regexDeCpf))
                return false;

            var digitosDoCpf = cpf.Substring(0, 9);
            var digitosVerificadoresDoCpf = cpf.Substring(9, 2);

            var DigitoVerificador1 = obterDigitoVerificador1(digitosDoCpf);

            var digitosDoCpfComDigitoVerificador1 = digitosDoCpf + DigitoVerificador1;

            var DigitoVerificador2 = obterDigitoVerificador2(digitosDoCpfComDigitoVerificador1);

            return digitosVerificadoresDoCpf.Equals(DigitoVerificador1.ToString() + DigitoVerificador2.ToString());
        }

        private static string obterDigitoVerificador1(string digitosDoCpf)
        {
            int[] multiplicadorDoDigitoVerificador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += int.Parse(digitosDoCpf[i].ToString()) * multiplicadorDoDigitoVerificador1[i];

            var resto = soma % 11;

            var DigitoVerificador1 = resto < 2 ? 0 : 11 - resto;

            return DigitoVerificador1.ToString();
        }

        private static string obterDigitoVerificador2(string digitosDoCpfComDigitoVerificador1)
        {
            int[] multiplicadorDoDigitoVerificador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var soma = 0;
            for (var i = 0; i < 10; i++)
                soma += int.Parse(digitosDoCpfComDigitoVerificador1[i].ToString()) * multiplicadorDoDigitoVerificador2[i];

            var resto = soma % 11;

            var DigitoVerificador2 = resto < 2 ? 0 : 11 - resto;

            return DigitoVerificador2.ToString();
        }

        public static bool ValidarEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            return Regex.IsMatch(email, _regexDeEmail);
        }
    }
}