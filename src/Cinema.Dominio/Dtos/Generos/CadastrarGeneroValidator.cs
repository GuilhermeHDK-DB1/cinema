using FluentValidation;

namespace Cinema.Dominio.Dtos.Generos
{
    public class CadastrarGeneroValidator : AbstractValidator<CadastrarGeneroCommand>
    {
        public CadastrarGeneroValidator()
        {
            RuleFor(genero => genero.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome obrigatório");
        }
    }
}
