using Cinema.Dominio.Common;
using Cinema.Dominio.Dtos.Filmes;
using Cinema.Dominio.Entities.Filmes;

namespace Cinema.Dominio.Services.Manipuladores
{
    public class ManipuladorDeFilme
    {
        private readonly IFilmeRepositorio _filmeRespositorio;
        private readonly IGeneroRepositorio _generoRespositorio;
        private readonly IUnitOfWork _unitOfWork;

        public ManipuladorDeFilme(IFilmeRepositorio filmeRepositorio, IGeneroRepositorio generoRespositorio, IUnitOfWork unitOfWork)
        {
            _filmeRespositorio = filmeRepositorio;
            _generoRespositorio = generoRespositorio;
            _unitOfWork = unitOfWork;
        }

        public FilmeResult Adicionar(CadastrarFilmeCommand filmeDto)
        {
            var genero = _generoRespositorio.ObterPeloNome(filmeDto.Genero);

            //var filme = new Filme(
            //    filmeDto.Nome,
            //    filmeDto.DataDeLancamento,
            //    filmeDto.Duracao,
            //    filmeDto.Classificacao,
            //    genero);

            var filme = new Filme(
                filmeDto.Nome);

            _filmeRespositorio.Adicionar(filme);

            _unitOfWork.Commit();

            return new FilmeResult(filme);
        }
    }
}
