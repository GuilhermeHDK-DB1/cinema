using FluentValidation;

namespace Cinema.Dominio.Dtos.Generos
{
    public class AtualizarGeneroValidator : AbstractValidator<AtualizarGeneroCommand>
    {
        public AtualizarGeneroValidator()
        {
            RuleFor(command => command.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(command => command.Nome)
                .NotNull()
                .NotEmpty();
        }
    }
}
