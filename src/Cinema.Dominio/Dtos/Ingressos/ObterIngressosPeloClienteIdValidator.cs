using FluentValidation;

namespace Cinema.Dominio.Dtos.Ingressos
{
    public class ObterIngressosPeloClienteIdValidator : AbstractValidator<ObterIngressosPeloClienteIdQuery>
    {
        public ObterIngressosPeloClienteIdValidator()
        {
            RuleFor(query => query.ClienteId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
