using Cinema.Dominio.Entities.Sessoes;
using System;
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

            //foreach (var horarioPermitido in horariosPermitidos)
            //{
            //    if (horarioPermitido.Hour.Equals(horario.Hour))
            //        return true;
            //}
            //return false;
        }

        public static bool ValidarIdiomas(Idiomas idioma)
        {
            return Enum.IsDefined(typeof(Idiomas), idioma);
        }
    }
}