﻿using Cinema.Dominio.Common;
using Cinema.Dominio.Extensions;
using FluentValidation;

namespace Cinema.Dominio.Dtos.Clientes
{
    public class ObterPeloEmailValidator : AbstractValidator<ObterPeloEmailQuery>
    {
        public ObterPeloEmailValidator()
        {
            RuleFor(query => query.Email)
                .Must(email => ValidatorExtension.ValidarEmail(email))
                .WithMessage(Resources.FormatoDeEmailInvalido);
        }
    }
}
