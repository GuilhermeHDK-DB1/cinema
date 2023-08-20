using Xunit;
using ExpectedObjects;
using Cinema.Dominio.Generos;
using Cinema.Dominio.Test._Util;
using Cinema.Dominio._Shared.RegrasDeNegocio;

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
            Assert.Throws<ExcecaoDeDominio>(
                () => new Genero(nomeInvalido)
            ).ComMensagem(Mensagens.GeneroInvalido);
        }
    }
}
