using FluentValidation;

namespace Cinema.Dominio.Dtos.Generos
{
    public class CadastrarGeneroValidator : AbstractValidator<CadastrarGeneroCommand>
    {
        public CadastrarGeneroValidator()
        {
            RuleFor(command => command.Nome)
                .NotNull()
                .NotEmpty();
        }
    }
}
