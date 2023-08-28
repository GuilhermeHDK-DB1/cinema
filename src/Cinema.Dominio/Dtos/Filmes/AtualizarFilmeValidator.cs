﻿using Cinema.Dominio.Common;
using Cinema.Dominio.Extensions;
using FluentValidation;

namespace Cinema.Dominio.Dtos.Filmes
{
    public class AtualizarFilmeValidator : AbstractValidator<AtualizarFilmeCommand>
    {
        public AtualizarFilmeValidator()
        {
            RuleFor(command => command.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(command => command.Nome)
                .NotNull()
                .NotEmpty();

            RuleFor(command => command.DataDeLancamento)
                .NotNull()
                .NotEmpty()
                .Matches("^(?!0000)\\d{4}$");

            RuleFor(command => command.Duracao)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(command => command.Classificacao)
                .Must(classificacao => ValidatorExtension.ValidarClassificacaoIndicativa(classificacao))
                .WithMessage(Resources.ClassificaoIndicativaInvalida);

            RuleFor(command => command.Genero)
                .NotNull()
                .NotEmpty();
        }
    }
}
