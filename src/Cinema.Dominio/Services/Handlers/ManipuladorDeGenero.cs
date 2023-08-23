using Cinema.Dominio.Common;
using Cinema.Dominio.Dtos.Generos;
using Cinema.Dominio.Entities.Generos;

namespace Cinema.Dominio.Services.Handlers
{
    public class ManipuladorDeGenero
    {
        private readonly IGeneroRepositorio _generoRepositorio;

        public ManipuladorDeGenero(IGeneroRepositorio generoRepositorio)
        {
            _generoRepositorio = generoRepositorio;
        }

        public GeneroReadDto Adicionar(GeneroCreateDto generoDto)
        {
            var generoJaSalvo = _generoRepositorio.ObterPeloNome(generoDto.Nome);

            ValidadorDeRegra.Novo()
                .Quando(generoJaSalvo != null, Resources.GeneroComMesmoNomeJaExiste)
                .DispararExcecaoSeExistir();

            var genero = new Genero(generoDto.Nome);
            _generoRepositorio.Adicionar(genero);

            return new GeneroReadDto(genero);
        }

        public GeneroReadDto Atualizar(int id, GeneroUpdateDto generoDto)
        {
            var genero = _generoRepositorio.ObterPorId(id);

            ValidadorDeRegra.Novo()
                .Quando(genero is null
                , Resources.GeneroComIdInexistente)
                .DispararExcecaoSeExistir();

            var generoJaSalvo = _generoRepositorio.ObterPeloNome(generoDto.Nome);

            ValidadorDeRegra.Novo()
                .Quando(string.IsNullOrEmpty(generoDto.Nome)
                , Resources.NomeInvalido)
                .Quando(generoJaSalvo != null &&
                    generoJaSalvo.Nome.Contains(genero.Nome) &&
                    generoJaSalvo.Id != genero.Id
                , Resources.GeneroComMesmoNomeJaExiste)
                .DispararExcecaoSeExistir();

            genero.Nome = generoDto.Nome;

            _generoRepositorio.Atualizar(genero);

            return new GeneroReadDto(genero);
        }
    }
}