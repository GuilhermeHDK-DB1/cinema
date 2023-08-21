using Bogus;
using Cinema.Dominio.Common;
using Cinema.Dominio.Dtos.Generos;
using Cinema.Dominio.Entities.Generos;
using Cinema.Dominio.Services;
using Cinema.Dominio.Services.Handlers;
using Cinema.Dominio.Test.Builders;
using Cinema.Dominio.Test.Utils;
using Moq;
using Xunit;

namespace Cinema.Dominio.Test.Generos
{
    public class ManipuladorDeGeneroTest
    {
        private readonly GeneroCreateDto _generoCreateDto;
        private readonly GeneroUpdateDto _generoUpdateDto;
        private readonly ManipuladorDeGenero _manipuladorDeGenero;
        private readonly Mock<IGeneroRepositorio> _generoRepositorioMock;

        public ManipuladorDeGeneroTest()
        {
            var faker = new Faker();
            _generoCreateDto = new GeneroCreateDto
            {
                Nome = faker.Random.Words()
            };

            _generoUpdateDto = new GeneroUpdateDto
            {
                Nome = faker.Random.Words()
            };

            _generoRepositorioMock = new Mock<IGeneroRepositorio>();

            _manipuladorDeGenero = new ManipuladorDeGenero(_generoRepositorioMock.Object);
        }

        [Fact]
        public void DeveAdicionarCurso()
        {
            _manipuladorDeGenero.Adicionar(_generoCreateDto);

            _generoRepositorioMock.Verify(r => r.Adicionar(
                It.Is<Genero>(
                    g => g.Nome == _generoCreateDto.Nome
                )
            ));
        }

        [Fact]
        public void NaoDeveAdicionarGeneroComMesmoNomeDeOutroJaSalvo()
        {
            var generoaSalvo = GeneroBuilder.Novo().ComId(432).ComNome(_generoCreateDto.Nome).Build();
            _generoRepositorioMock.Setup(r => r.ObterPeloNome(_generoCreateDto.Nome)).Returns(generoaSalvo);

            Assert.Throws<ExcecaoDeDominio>(() => _manipuladorDeGenero.Adicionar(_generoCreateDto))
                .ComMensagem(Resources.NomeDoGeneroJaExiste);
        }

        //[Fact]
        //public void DeveAlterarDadosDoCurso()
        //{
        //    _cursoDto.Id = 323;
        //    var curso = CursoBuilder.Novo().Build();
        //    _cursoRepositorioMock.Setup(r => r.ObterPorId(_cursoDto.Id)).Returns(curso);

        //    _armazenadorDeCurso.Armazenar(_cursoDto);

        //    Assert.Equal(_cursoDto.Nome, curso.Nome);
        //    Assert.Equal(_cursoDto.Valor, curso.Valor);
        //    Assert.Equal(_cursoDto.CargaHoraria, curso.CargaHoraria);
        //}

        //[Fact]
        //public void NaoDeveAdicionarNoRepositorioQuandoCursoJaExiste()
        //{
        //    _cursoDto.Id = 323;
        //    var curso = CursoBuilder.Novo().Build();
        //    _cursoRepositorioMock.Setup(r => r.ObterPorId(_cursoDto.Id)).Returns(curso);

        //    _armazenadorDeCurso.Armazenar(_cursoDto);

        //    _cursoRepositorioMock.Verify(r => r.Adicionar(It.IsAny<Curso>()), Times.Never);
        //}
    }
}
