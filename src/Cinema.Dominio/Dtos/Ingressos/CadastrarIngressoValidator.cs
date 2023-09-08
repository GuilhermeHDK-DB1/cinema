using Cinema.Dominio.Common;
using Cinema.Dominio.Extensions;
using FluentValidation;

namespace Cinema.Dominio.Dtos.Ingressos
{
    public class CadastrarIngressoValidator : AbstractValidator<CadastrarIngressoCommand>
    {
        public CadastrarIngressoValidator()
        {
            RuleFor(command => command.ClienteId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(command => command.SessaoId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(command => command.Tipo)
                .Must(tipo => ValidatorExtension.ValidarTipoDeIngresso(tipo))
                .WithMessage(Resources.TipoDeIngressoInvalido);
        }
    }
}
