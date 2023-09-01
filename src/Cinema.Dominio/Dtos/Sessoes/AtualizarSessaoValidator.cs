using Cinema.Dominio.Common;
using Cinema.Dominio.Extensions;
using FluentValidation;

namespace Cinema.Dominio.Dtos.Sessoes
{
    public class AtualizarSessaoValidator : AbstractValidator <AtualizarSessaoCommand>
    {
        public AtualizarSessaoValidator()
        {
            RuleFor(command => command.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(command => command.FilmeId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(command => command.SalaId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(command => command.Horario)
                .Must(horario => ValidatorExtension.ValidarHorario(horario))
                .WithMessage(Resources.FormatoDeHorarioInvalido);

            RuleFor(command => command.Idioma)
                .NotNull()
                .Must(idioma => ValidatorExtension.ValidarIdiomas(idioma))
                .WithMessage(Resources.IdiomaInvalido);
        }
    }
}
