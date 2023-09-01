using FluentValidation;

namespace Cinema.Dominio.Dtos.Sessoes
{
    public class ExcluirSessaoValidator : AbstractValidator<ExcluirSessaoQuery>
    {
        public ExcluirSessaoValidator()
        {
            RuleFor(query => query.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
