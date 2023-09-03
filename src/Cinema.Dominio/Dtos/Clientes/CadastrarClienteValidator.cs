using Cinema.Dominio.Common;
using Cinema.Dominio.Extensions;
using FluentValidation;

namespace Cinema.Dominio.Dtos.Clientes
{
    public class CadastrarClienteValidator : AbstractValidator<CadastrarClienteCommand>
    {
        public CadastrarClienteValidator()
        {
            RuleFor(cliente => cliente.Nome)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(cliente => cliente.Cpf)
                .Must(cpf => ValidatorExtension.ValidarCpf(cpf))
                .WithMessage(Resources.FormatoDeCpfInvalido);

            RuleFor(cliente => cliente.Email)
                .Must(email => ValidatorExtension.ValidarEmail(email))
                .WithMessage(Resources.FormatoDeEmailInvalido);

            RuleFor(cliente => cliente.DataDeNascimento)
                .Must(data => ValidatorExtension.ValidarData(data))
                .WithMessage(Resources.FormatoDeDataInvalida);
        }
    }
}
