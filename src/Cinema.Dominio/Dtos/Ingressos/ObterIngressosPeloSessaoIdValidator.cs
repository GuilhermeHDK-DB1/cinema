using FluentValidation;

namespace Cinema.Dominio.Dtos.Ingressos
{
    public class ObterIngressosPeloSessaoIdValidator : AbstractValidator<ObterIngressosPeloSessaoIdQuery>
    {
        public ObterIngressosPeloSessaoIdValidator()
        {
            RuleFor(query => query.SessaoId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
