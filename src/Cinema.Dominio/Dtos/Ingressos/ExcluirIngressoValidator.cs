using FluentValidation;

namespace Cinema.Dominio.Dtos.Ingressos
{
    public class ExcluirIngressoValidator : AbstractValidator<ExcluirIngressoQuery>
    {
        public ExcluirIngressoValidator()
        {
            RuleFor(query => query.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
