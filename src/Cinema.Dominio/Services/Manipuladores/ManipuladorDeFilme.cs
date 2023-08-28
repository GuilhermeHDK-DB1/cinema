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
            // TODO: verificar se é possível validar com nome de gênero existente

            var filme = new Filme(
                nome: filmeDto.Nome,
                dataDeLancamento: filmeDto.DataDeLancamento,
                duracao: filmeDto.Duracao,
                classificacao: filmeDto.Classificacao,
                genero: genero);

            _filmeRespositorio.Adicionar(filme);

            _unitOfWork.Commit();

            return new FilmeResult(filme);
        }

        public FilmeResult Atualizar(AtualizarFilmeCommand filmeDto)
        {
            var filme = _filmeRespositorio.ObterPorId(filmeDto.Id);

            if (filme == null) new Exception("Id do filme informado não existe");

            ValidadorDeRegra.Novo()
                .Quando(filme is null, Resources.FilmeComIdInexistente)
                .DispararExcecaoSeExistir();
            
            var genero = _generoRespositorio.ObterPeloNome(filmeDto.Genero);

            filme.AlterarNome(filmeDto.Nome);
            filme.AlterarDataDeLancamento(filmeDto.DataDeLancamento);
            filme.AlterarDuracao(filmeDto.Duracao);
            filme.AlterarClassificacao(filmeDto.Classificacao);
            filme.AlterarGenero(genero);

            _filmeRespositorio.Atualizar(filme);

            return new FilmeResult(filme);
        }

        public int? Excluir(int id)
        {
            var filme = _filmeRespositorio.ObterPorId(id);

            if (filme == null) return null;

            _filmeRespositorio.Excluir(filme);

            return _unitOfWork.Commit();
        }
    }
}
