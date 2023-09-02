using Cinema.Dominio.Entities.Sessoes;
using System.Text.RegularExpressions;

namespace Cinema.Dominio.Extensions
{
    public static class ValidatorExtension
    {
        public static bool ValidarClassificacaoIndicativa(string classificacao)
        {
            if (string.IsNullOrEmpty(classificacao)) return false;

            return ClassificacaoIndicativaExtension.Dicionario.ContainsValue(classificacao);
        }

        public static bool ValidarData(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;

            string regexDeData = "^\\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$";

            return Regex.IsMatch(data, regexDeData);
        }

        public static bool ValidarHorario(string horario)
        {
            if (string.IsNullOrEmpty(horario)) return false;

            string regexDeHorario = "^\\d{4}-\\d{2}-\\d{2} \\d{2}:\\d{2}:\\d{2}$";

            return Regex.IsMatch(horario, regexDeHorario);
        }

        public static bool ValidarHorarioPermitido(string horarioString)
        {
            DateTime.TryParse(horarioString, out DateTime horario);

            if (horario == null) return false;

            var horariosPermitidos = new List<DateTime>
            {
                new DateTime(1, 1, 1, 10, 0, 0),
                new DateTime(1, 1, 1, 13, 0, 0),
                new DateTime(1, 1, 1, 16, 0, 0),
                new DateTime(1, 1, 1, 19, 0, 0),
                new DateTime(1, 1, 1, 22, 0, 0)
            };

            return horariosPermitidos.Any(horarioPermitido => 
                horarioPermitido.Hour.Equals(horario.Hour) &&
                horarioPermitido.Minute.Equals(horario.Minute) &&
                horarioPermitido.Second.Equals(horario.Second));

            //testar usar TimeSpan no lugar de DateTime
        }

        public static bool ValidarIdiomas(Idiomas idioma)
        {
            return Enum.IsDefined(typeof(Idiomas), idioma);
        }

        public static bool ValidarCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;
            
            string regexDeCpf = "^\\d{11}$";

            if (!Regex.IsMatch(cpf, regexDeCpf))
                return false;

            int[] multiplicadorDoDigitoVerificador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadorDoDigitoVerificador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var digitosDoCpf = cpf.Substring(0, 9);
            var digitosVerificadoresDoCpf = cpf.Substring(9, 2);

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += int.Parse(digitosDoCpf[i].ToString()) * multiplicadorDoDigitoVerificador1[i];

            var resto = soma % 11;

            var DigitoVerificador1 = resto < 2 ? 0 : 11 - resto;

            var digitosDoCpfComDigitoVerificador1 = digitosDoCpf + DigitoVerificador1.ToString();

            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += int.Parse(digitosDoCpfComDigitoVerificador1[i].ToString()) * multiplicadorDoDigitoVerificador2[i];

            resto = soma % 11;

            var DigitoVerificador2 = resto < 2 ? 0 : 11 - resto;

            return digitosVerificadoresDoCpf.Equals(DigitoVerificador1.ToString() + DigitoVerificador2.ToString());
        }

        public static bool ValidarEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            string regexDeEmail = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";

            return Regex.IsMatch(email, regexDeEmail);
        }
    }
}