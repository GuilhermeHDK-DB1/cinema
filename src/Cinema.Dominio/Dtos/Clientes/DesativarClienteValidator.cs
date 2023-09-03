using FluentValidation;

namespace Cinema.Dominio.Dtos.Clientes
{
    public class DesativarClienteValidator : AbstractValidator<DesativarClienteQuery>
    {
        public DesativarClienteValidator()
        {
            RuleFor(cliente => cliente.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
