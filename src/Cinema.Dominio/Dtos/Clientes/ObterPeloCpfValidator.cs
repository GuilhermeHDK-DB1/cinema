using Cinema.Dominio.Common;
using Cinema.Dominio.Extensions;
using FluentValidation;

namespace Cinema.Dominio.Dtos.Clientes
{
    public class ObterPeloCpfValidator : AbstractValidator<ObterPeloCpfQuery>
    {
        public ObterPeloCpfValidator()
        {
            RuleFor(query => query.Cpf)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
