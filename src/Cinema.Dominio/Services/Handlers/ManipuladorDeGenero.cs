﻿using Cinema.Dominio.Common;
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

        public GeneroReadDto Atualizar(GeneroUpdateDto generoDto)
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

            return new GeneroReadDto(genero);
        }

        public int? Excluir(int id)
        {
            var genero = _generoRepositorio.ObterPorId(id);

            if (genero == null) return null;

            _generoRepositorio.Excluir(genero);

            var linhasAfetadas = 1; //_unitOfWork.Commit() ?? 0;

            /*
             TODO: alterar retorno de UnitOfWork de Task para int
             */

            return linhasAfetadas;
        }
    }
}