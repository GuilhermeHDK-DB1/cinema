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

namespace Cinema.Dominio.Test.Generos;

public class ManipuladorDeGeneroTest
{
    private readonly Faker _faker;
    private readonly GeneroCreateDto _generoCreateDto;
    private readonly GeneroUpdateDto _generoUpdateDto;
    private readonly ManipuladorDeGenero _manipuladorDeGenero;
    private readonly Mock<IGeneroRepositorio> _generoRepositorioMock;

    public ManipuladorDeGeneroTest()
    {
        _faker = new Faker();

        _generoCreateDto = new GeneroCreateDto
        {
            Nome = _faker.Random.Words()
        };

        _generoUpdateDto = new GeneroUpdateDto
        {
            Nome = _faker.Random.Words()
        };

        _generoRepositorioMock = new Mock<IGeneroRepositorio>();

        _manipuladorDeGenero = new ManipuladorDeGenero(_generoRepositorioMock.Object);
    }

    [Fact]
    public void DeveAdicionarGenero()
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
        _generoCreateDto.Nome = _faker.Random.Words();

        var generoJaSalvo = GeneroBuilder.Novo().ComNome(_generoCreateDto.Nome).Build();

        _generoRepositorioMock.Setup(r => r.ObterPeloNome(_generoCreateDto.Nome))
            .Returns(generoJaSalvo);

        Assert.Throws<ExcecaoDeDominio>(() => _manipuladorDeGenero.Adicionar(_generoCreateDto))
            .ComMensagem(Resources.GeneroComMesmoNomeJaExiste);
    }

    [Fact]
    public void DeveAtualizarDadosDoGenero()
    {
        var id = _faker.Random.Int(1, 9999);

        var genero = GeneroBuilder.Novo().Build();

        Genero? generoNulo = null;

        _generoRepositorioMock.Setup(r => r.ObterPorId(id)).Returns(genero);

        _generoRepositorioMock.Setup(r => r.ObterPeloNome(_generoUpdateDto.Nome)).Returns(generoNulo);

        _manipuladorDeGenero.Atualizar(id, _generoUpdateDto);

        Assert.Equal(_generoUpdateDto.Nome, genero.Nome);
    }

    [Fact]
    public void NaoDeveAtualizarDadosDoGeneroSeIdInexistente()
    {
        var id = _faker.Random.Int(1, 9999);

        Genero? generoNulo = null;

        _generoRepositorioMock.Setup(r => r.ObterPorId(id)).Returns(generoNulo);

        Assert.Throws<ExcecaoDeDominio>(() => _manipuladorDeGenero.Atualizar(id, _generoUpdateDto))
            .ComMensagem(Resources.GeneroComIdInexistente);
    }

    [Fact]
    public void NaoDeveAtualizarGeneroNomeJaSalvoNoBanco()
    {
        var id = _faker.Random.Int(1, 100);
        var idJaSalvo = _faker.Random.Int(101, 200);
        var nomeJaSalvo = _generoUpdateDto.Nome;

        var genero = GeneroBuilder.Novo().ComId(id).Build();
        var generoComMesmoNomeJaSalvo = GeneroBuilder.Novo().ComId(idJaSalvo).ComNome(nomeJaSalvo).Build();

        _generoRepositorioMock
            .Setup(r => r.ObterPorId(id))
            .Returns(genero);
        _generoRepositorioMock
            .Setup(r => r.ObterPeloNome(nomeJaSalvo))
            .Returns(generoComMesmoNomeJaSalvo);

        Assert.Throws<ExcecaoDeDominio>(() => _manipuladorDeGenero.Atualizar(id, _generoUpdateDto))
            .ComMensagem(Resources.GeneroComMesmoNomeJaExiste);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void NaoDeveAtualizarGeneroComMesmoInvalido(string nomeInvalido)
    {
        var id = _faker.Random.Int(1, 100);
        _generoUpdateDto.Nome = nomeInvalido;

        var genero = GeneroBuilder.Novo().Build();
        Genero? generoNulo = null;


        _generoRepositorioMock
            .Setup(r => r.ObterPorId(id))
            .Returns(genero);
        _generoRepositorioMock
            .Setup(r => r.ObterPeloNome(_generoUpdateDto.Nome))
            .Returns(generoNulo);

        Assert.Throws<ExcecaoDeDominio>(() => _manipuladorDeGenero.Atualizar(id, _generoUpdateDto))
            .ComMensagem(Resources.NomeInvalido);
    }
}
