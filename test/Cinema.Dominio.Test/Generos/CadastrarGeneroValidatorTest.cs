using Bogus;
using Cinema.Dominio.Dtos.Generos;
using Xunit;

namespace Cinema.Dominio.Test.Generos;

public class CadastrarGeneroValidatorTest
{
    private CadastrarGeneroValidator _validator;
    private Faker _faker;

    public CadastrarGeneroValidatorTest()
    {
        _validator = new CadastrarGeneroValidator();
        _faker = new Faker();
    }

    [Fact]
    public void Validator_QuandoCommandForInvalido_DeveRetornarErro()
    {
        var request = new CadastrarGeneroCommand();

        var resultadoDaValidacao = _validator.Validate(request);

        var quantidadeDeErrosEsperados = 2;

        Assert.Multiple(() =>
        {
            Assert.False(resultadoDaValidacao.IsValid);
            Assert.Equal(quantidadeDeErrosEsperados, resultadoDaValidacao.Errors.Count());
        });
    }

    [Fact]
    public void Validator_QuandoCommandForValido_DeveRetornarSucesso()
    {
        var request = new CadastrarGeneroCommand
        {
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
