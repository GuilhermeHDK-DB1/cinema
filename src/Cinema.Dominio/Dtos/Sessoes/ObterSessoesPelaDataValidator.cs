using FluentValidation;

namespace Cinema.Dominio.Dtos.Sessoes
{
    public class ObterSessoesPelaDataValidator : AbstractValidator<ObterSessoesPelaDataQuery>
    {
        public ObterSessoesPelaDataValidator()
        {
            RuleFor(query => query.Data)
                .NotNull()
                .NotEmpty()
                .Matches("^\\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$")
                .WithMessage("Data deve seguir o formato AAAA-MM-DD");
        }
    }
}
