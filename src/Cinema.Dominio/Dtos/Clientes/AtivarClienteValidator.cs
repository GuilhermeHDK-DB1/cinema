using FluentValidation;

namespace Cinema.Dominio.Dtos.Clientes
{
    public  class AtivarClienteValidator : AbstractValidator<AtivarClienteQuery>
    {
        public AtivarClienteValidator()
        {
            RuleFor(cliente => cliente.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
