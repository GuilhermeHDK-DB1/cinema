using Bogus;
using Cinema.Dominio.Common;
using Cinema.Dominio.Dtos.Generos;
using Cinema.Dominio.Entities.Generos;
using Cinema.Dominio.Services.Manipuladores;
using Cinema.Dominio.Test.Builders;
using Xunit;

namespace Cinema.Dominio.Test.Generos;

public class AtualizarGeneroValidatorTest
{
    private AtualizarGeneroValidator _validator;
    private Faker _faker;

    public AtualizarGeneroValidatorTest()
    {
        _validator = new AtualizarGeneroValidator();
        _faker = new Faker();
    }

    [Fact]
    public void Validator_QuandoNomeForInvalido_DeveRetornarErro()
    {
        var request = new AtualizarGeneroCommand();

        var resultadoDaValidacao = _validator.Validate(request);

        var quantidadeDeErrosEsperados = 4;

        Assert.Multiple(() =>
        {
            Assert.False(resultadoDaValidacao.IsValid);
            Assert.Equal(quantidadeDeErrosEsperados, resultadoDaValidacao.Errors.Count());
        });
    }

    [Fact]
    public void Validator_QuandoCommandForValido_DeveRetornarSucesso()
    {
        var request = new AtualizarGeneroCommand
        {
            Id = _faker.Random.Int(1, 9999),
            Nome = _faker.Random.Words()
        };

        var resultadoDaValidacao = _validator.Validate(request);

        var quantidadeDeErrosEsperados = 0;

        Assert.Multiple(() =>
        {
            Assert.True(resultadoDaValidacao.IsValid);
            Assert.Equal(quantidadeDeErrosEsperados, resultadoDaValidacao.Errors.Count());
        });
    }
}
