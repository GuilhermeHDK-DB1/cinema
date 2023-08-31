using Cinema.Dominio.Common;
using Cinema.Dominio.Extensions;
using FluentValidation;

namespace Cinema.Dominio.Dtos.Sessoes
{
    public class ObterSessoesPorFilmeEDataValidator : AbstractValidator<ObterSessoesPorFilmeEDataQuery>
    {
        public ObterSessoesPorFilmeEDataValidator()
        {
            RuleFor(query => query.FilmeId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(query => query.Data)
                .Must(data => ValidatorExtension.ValidarData(data))
                .WithMessage(Resources.FormatoDeDataInvalida);
        }
    }
}
