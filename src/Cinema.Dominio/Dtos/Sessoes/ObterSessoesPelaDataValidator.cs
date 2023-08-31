using Cinema.Dominio.Common;
using Cinema.Dominio.Extensions;
using FluentValidation;

namespace Cinema.Dominio.Dtos.Sessoes
{
    public class ObterSessoesPelaDataValidator : AbstractValidator<ObterSessoesPelaDataQuery>
    {
        public ObterSessoesPelaDataValidator()
        {
            RuleFor(query => query.Data)
                .Must(data => ValidatorExtension.ValidarData(data))
                .WithMessage(Resources.FormatoDeDataInvalida);
        }
    }
}
