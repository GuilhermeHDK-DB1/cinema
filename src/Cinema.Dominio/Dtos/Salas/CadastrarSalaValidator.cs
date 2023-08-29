using FluentValidation;

namespace Cinema.Dominio.Dtos.Salas
{
    public class CadastrarSalaValidator : AbstractValidator<CadastrarSalaCommand>
    {
        public CadastrarSalaValidator()
        {
            RuleFor(command => command.Nome)
                .NotNull()
                .NotEmpty();

            RuleFor(command => command.SalaVip)
                .NotNull()
                .NotEmpty();

            RuleFor(command => command.Sala3D)
                .NotNull()
                .NotEmpty();

            RuleFor(command => command.Capacidade)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
