using Bogus;
using Cinema.Dominio.Common;
using Cinema.Dominio.Common.Notifications;
using Cinema.Dominio.Dtos.Generos;
using Cinema.Dominio.Entities.Generos;
using Cinema.Dominio.Services;
using Cinema.Dominio.Services.Manipuladores;
using Cinema.Dominio.Test.Builders;
using Cinema.Dominio.Test.Utils;
using Moq;
using Xunit;

namespace Cinema.Dominio.Test.Generos;

public class ManipuladorDeGeneroTest
{
    private readonly Faker _faker;
    private readonly Mock<IGeneroRepositorio> _generoRepositorioMock;
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly Mock<NotificationContext> _notificationContext;
    private readonly ManipuladorDeGenero _manipuladorDeGenero;

    public ManipuladorDeGeneroTest()
    {
        _faker = new Faker();

        _unitOfWork = new Mock<IUnitOfWork>();

        _generoRepositorioMock = new Mock<IGeneroRepositorio>();

        _manipuladorDeGenero = new ManipuladorDeGenero(_generoRepositorioMock.Object, _unitOfWork.Object, _notificationContext.Object);
    }

    private ExcluirGeneroQuery Setup_ExcluirGeneroQuery()
    {
        return new ExcluirGeneroQuery
        {
            Id = _faker.Random.Int(1, 100)
        };
    }

    private AtualizarGeneroCommand Setup_AtualizarGeneroCommand()
    {
        return new AtualizarGeneroCommand
        {
            Id = _faker.Random.Int(1, 100),
            Nome = _faker.Random.Words()
        };
    }

    private CadastrarGeneroCommand Setup_CadastrarGeneroCommand()
    {
        return new CadastrarGeneroCommand
        {
            Nome = _faker.Random.Words()
        };
    }

    [Fact]
    public void Service_QuandoGeneroForValido_DeveAdicionar()
    {
        var generoDto = Setup_CadastrarGeneroCommand();

        Genero? generoJaSalvo = null;

        _generoRepositorioMock.Setup(r => r.ObterPeloNome(generoDto.Nome))
            .Returns(generoJaSalvo);

        _manipuladorDeGenero.Adicionar(generoDto);

        _generoRepositorioMock.Verify(repo => 
            repo.Adicionar(It.Is<Genero>(genero =>
            genero.Nome == generoDto.Nome)), Times.Once);
    }

    [Fact]
    public void Service_QuandoGeneroComMesmoNomeDeOutroJaSalvo_NaoDeveAdicionar()
    {
        var generoDto = Setup_CadastrarGeneroCommand();

        var generoJaSalvo = GeneroBuilder.Novo().ComNome(generoDto.Nome).Build();

        _generoRepositorioMock.Setup(r => r.ObterPeloNome(generoDto.Nome))
            .Returns(generoJaSalvo);

        Assert.Throws<ExcecaoDeDominio>(() => _manipuladorDeGenero.Adicionar(generoDto))
            .ComMensagem(Resources.GeneroComMesmoNomeJaExiste);
    }

    [Fact]
    public void Service_QuandoNaoTiverGeneroComMesmoNomeDeOutroJaSalvo_DeveAtualizar()
    {
        var generoDto = Setup_AtualizarGeneroCommand();

        var genero = GeneroBuilder.Novo().Build();

        Genero? generoJaSalvo = null;

        _generoRepositorioMock.Setup(r => r.ObterPorId(generoDto.Id)).Returns(genero);

        _generoRepositorioMock.Setup(r => r.ObterPeloNome(generoDto.Nome)).Returns(generoJaSalvo);

        _manipuladorDeGenero.Atualizar(generoDto);

        Assert.Equal(generoDto.Nome, genero.Nome);
    }

    [Fact]
    public void Service_QuandoNaoEncontrarGeneroPorId_NaoDeveAtualizar()
    {
        var generoDto = Setup_AtualizarGeneroCommand();

        Genero? generoNulo = null;

        _generoRepositorioMock.Setup(r => r.ObterPorId(generoDto.Id)).Returns(generoNulo);

        Assert.Throws<ExcecaoDeDominio>(() => _manipuladorDeGenero.Atualizar(generoDto))
            .ComMensagem(Resources.GeneroComIdInexistente);
    }

    [Fact]
    public void Service_QuandoTiverGeneroComMesmoNomeDeOutroJaSalvo_NaoDeveAtualizar()
    {
        var generoDto = Setup_AtualizarGeneroCommand();
        var idJaSalvo = _faker.Random.Int(101, 200);
        var nomeJaSalvo = generoDto.Nome;

        var genero = GeneroBuilder.Novo().ComId(generoDto.Id).Build();
        var generoComMesmoNomeJaSalvo = GeneroBuilder.Novo().ComId(idJaSalvo).ComNome(nomeJaSalvo).Build();

        _generoRepositorioMock.Setup(r => r.ObterPorId(generoDto.Id)).Returns(genero);
        _generoRepositorioMock.Setup(r => r.ObterPeloNome(nomeJaSalvo)).Returns(generoComMesmoNomeJaSalvo);

        Assert.Throws<ExcecaoDeDominio>(() => _manipuladorDeGenero.Atualizar(generoDto))
            .ComMensagem(Resources.GeneroComMesmoNomeJaExiste);
    }

    [Fact]
    public void Service_QuandoEncontrarGeneroPorId_DeveExcluir()
    {
        var generoDto = Setup_ExcluirGeneroQuery();

        var generoJaSalvo = GeneroBuilder.Novo().ComId(generoDto.Id).Build();

        _generoRepositorioMock.Setup(r => r.ObterPorId(generoDto.Id)).Returns(generoJaSalvo);

        _manipuladorDeGenero.Excluir(generoDto.Id);

        _generoRepositorioMock.Verify(r =>
            r.Excluir(It.Is<Genero>(genero => 
            genero.Id == generoDto.Id)),Times.Once);
    }

    [Fact]
    public void Service_QuandoNaoEncontrarGeneroPorId_NaoDeveExcluir()
    {
        var generoDto = Setup_ExcluirGeneroQuery();

        Genero? generoJaSalvo = null;

        _generoRepositorioMock.Setup(r => r.ObterPorId(generoDto.Id)).Returns(generoJaSalvo);

        _manipuladorDeGenero.Excluir(generoDto.Id);

        _generoRepositorioMock.Verify(r =>
            r.Excluir(It.Is<Genero>(genero =>
            genero.Id == generoDto.Id)), Times.Never);
    }
}
