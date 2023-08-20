using Xunit;
using ExpectedObjects;
using Cinema.Dominio.Generos;

namespace Cinema.Dominio.Test.Generos
{
    public class GeneroTest
    {
        [Fact]
        public void DeveCriarGenero()
        {
            var generoEsperado = new
            {
                Nome = "Acao"
            };

            var genero = new Genero(generoEsperado.Nome);

            generoEsperado.ToExpectedObject().ShouldMatch(genero);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCriarGeneroComNomeInvalido(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(
                () => new Genero(nomeInvalido)
            );
        }
    }
}
