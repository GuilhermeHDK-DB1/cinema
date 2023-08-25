using Cinema.Dominio.Common;
using Cinema.Dominio.Dtos.Generos;
using Cinema.Dominio.Entities.Generos;

namespace Cinema.Dominio.Services.Manipuladores
{
    public class ManipuladorDeGenero
    {
        private readonly IGeneroRepositorio _generoRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public ManipuladorDeGenero(IGeneroRepositorio generoRepositorio, IUnitOfWork unitOfWork)
        {
            _generoRepositorio = generoRepositorio;
            _unitOfWork = unitOfWork;
        }

        public GeneroResult Adicionar(CadastrarGeneroCommand generoDto)
        {
            var generoJaSalvo = _generoRepositorio.ObterPeloNome(generoDto.Nome);

            ValidadorDeRegra.Novo()
                .Quando(generoJaSalvo != null, Resources.GeneroComMesmoNomeJaExiste)
                .DispararExcecaoSeExistir();

            var genero = new Genero(generoDto.Nome);
            _generoRepositorio.Adicionar(genero);

            _unitOfWork.Commit();

            return new GeneroResult(genero);
        }

        public GeneroResult Atualizar(AtualizarGeneroCommand generoDto)
        {
            var genero = _generoRepositorio.ObterPorId(generoDto.Id);

            if (genero == null) new Exception("Id do gênero informado não existe");

            ValidadorDeRegra.Novo()
                .Quando(genero is null, Resources.GeneroComIdInexistente)
                .DispararExcecaoSeExistir();

            var generoJaSalvo = _generoRepositorio.ObterPeloNome(generoDto.Nome);

            ValidadorDeRegra.Novo()
                .Quando(generoJaSalvo != null &&
                    generoJaSalvo.Nome.Contains(generoDto.Nome) &&
                    generoJaSalvo.Id != genero.Id,
                    Resources.GeneroComMesmoNomeJaExiste)
                .DispararExcecaoSeExistir();

            genero.AlterarNome(generoDto.Nome);

            _generoRepositorio.Atualizar(genero);

            return new GeneroResult(genero);
        }

        public int? Excluir(int id)
        {
            var genero = _generoRepositorio.ObterPorId(id);

            if (genero == null) return null;

            _generoRepositorio.Excluir(genero);

            return _unitOfWork.Commit();
        }
    }
}