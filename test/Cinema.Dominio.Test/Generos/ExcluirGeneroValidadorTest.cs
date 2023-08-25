using Bogus;
using Cinema.Dominio.Dtos.Generos;
using Xunit;

namespace Cinema.Dominio.Test.Generos
{
    public class ExcluirGeneroValidadorTest
    {
        private ExcluirGeneroValidator _validator;
        private Faker _faker;

        public ExcluirGeneroValidadorTest()
        {
            _validator = new ExcluirGeneroValidator();
            _faker = new Faker();
        }

        [Fact]
        public void Validator_QuandoQueryForInvalido_DeveRetornarErro()
        {
            var request = new ExcluirGeneroQuery();

            var resultadoDaValidacao = _validator.Validate(request);

            var quantidadeDeErrosEsperados = 2;

            Assert.Multiple(() =>
            {
                Assert.False(resultadoDaValidacao.IsValid);
                Assert.Equal(quantidadeDeErrosEsperados, resultadoDaValidacao.Errors.Count());
            });
        }

        [Fact]
        public void Validator_QuandoQueryForValido_DeveRetornarSucesso()
        {
            var request = new ExcluirGeneroQuery
            {
                Id = _faker.Random.Int(1, 9999)
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
}
