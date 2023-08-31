using Cinema.Dominio.Common;
using Cinema.Dominio.Extensions;
using FluentValidation;

namespace Cinema.Dominio.Dtos.Sessoes
{
    public class ObterSessoesPorHorarioValidator : AbstractValidator<ObterSessoesPorHorarioQuery>
    {
        public ObterSessoesPorHorarioValidator()
        {
            RuleFor(query => query.Horario)
                .Must(horario => ValidatorExtension.ValidarHorario(horario))
                .WithMessage(Resources.FormatoDeHorarioInvalido);
        }
    }
}
