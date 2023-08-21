using Cinema.Dominio.Common;
using Cinema.Dominio.Dtos;
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

        public void Armazenar(GeneroDto generoDto)
        {
            var generoJaSalvo = _generoRepositorio.ObterPeloNome(generoDto.Nome);
            ValidadorDeRegra.Novo()
                .Quando(generoJaSalvo != null && generoJaSalvo.Id != generoDto.Id, Resources.NomeDoGeneroJaExiste)
                .DispararExcecaoSeExistir();

            var genero = new Genero(generoDto.Nome);

            if (generoDto.Id > 0)
            {
                genero = _generoRepositorio.ObterPorId(generoDto.Id);
                genero.AlterarNome(generoDto.Nome);
            }

            if (generoDto.Id == 0)
                _generoRepositorio.Adicionar(genero);
        }
    }
}