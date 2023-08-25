using Xunit;
using Bogus;
using ExpectedObjects;
using Cinema.Dominio.Test.Builders;

namespace Cinema.Dominio.Test.Generos
{
    public class GeneroTest
    {
        private readonly Faker _faker;
        private readonly int _id;
        private readonly string _nome;

        public GeneroTest()
        {
            _faker = new Faker();

            _id = _faker.Random.Int(1, 100);
            _nome = _faker.Random.String();
        }

        [Fact]
        public void DeveCriarGenero()
        {
            var generoEsperado = new
            {
                Nome = _nome
            };

            var genero = GeneroBuilder.Novo().ComNome(generoEsperado.Nome)
                .Build();

            generoEsperado.ToExpectedObject().ShouldMatch(genero);
        }

        [Fact]
        public void DeveCriarGeneroComId()
        {
            var generoEsperado = new
            {
                Id = _id,
                Nome = _nome
            };

            var genero = GeneroBuilder.Novo()
                .ComId(generoEsperado.Id)
                .ComNome(generoEsperado.Nome)
                .Build();

            generoEsperado.ToExpectedObject().ShouldMatch(genero);
        }

        [Fact]
        public void DeveAlterarNome()
        {
            var nomeEsperado = _faker.Person.FullName;
            var genero = GeneroBuilder.Novo().Build();

            genero.AlterarNome(nomeEsperado);

            Assert.Equal(nomeEsperado, genero.Nome);
        }
    }
}
