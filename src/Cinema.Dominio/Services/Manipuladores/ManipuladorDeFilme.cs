﻿using Cinema.Dominio.Common;
using Cinema.Dominio.Common.Notifications;
using Cinema.Dominio.Dtos.Filmes;
using Cinema.Dominio.Entities.Filmes;

namespace Cinema.Dominio.Services.Manipuladores
{
    public class ManipuladorDeFilme
    {
        private readonly IFilmeRepositorio _filmeRespositorio;
        private readonly IGeneroRepositorio _generoRespositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly NotificationContext _notificationContext;

        public ManipuladorDeFilme(IFilmeRepositorio filmeRepositorio, IGeneroRepositorio generoRespositorio, IUnitOfWork unitOfWork, NotificationContext notificationContext)
        {
            _filmeRespositorio = filmeRepositorio;
            _generoRespositorio = generoRespositorio;
            _unitOfWork = unitOfWork;
            _notificationContext = notificationContext;
        }

        public FilmeResult Adicionar(CadastrarFilmeCommand filmeDto)
        {
            var genero = _generoRespositorio.ObterPeloNome(filmeDto.Genero);
            if (genero is null)
                _notificationContext.AddNotification($"Nome: {filmeDto.Genero}", Resources.GeneroComNomeInexistente);

            if (_notificationContext.HasNotifications)
                return default;

            var filme = new Filme(
                nome: filmeDto.Nome,
                anoDeLancamento: filmeDto.AnoDeLancamento,
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
            var genero = _generoRespositorio.ObterPeloNome(filmeDto.Genero);
            

            if (filme is null)
                _notificationContext.AddNotification($"Id: {filmeDto.Id}", Resources.FilmeComIdInexistente);

            if (genero is null)
                _notificationContext.AddNotification($"Nome: {filmeDto.Genero}", Resources.GeneroComNomeInexistente);

            if (_notificationContext.HasNotifications)
                return default;

            filme.AlterarNome(filmeDto.Nome);
            filme.AlterarAnoDeLancamento(filmeDto.AnoDeLancamento);
            filme.AlterarDuracao(filmeDto.Duracao);
            filme.AlterarClassificacao(filmeDto.Classificacao);
            filme.AlterarGenero(genero);

            _filmeRespositorio.Atualizar(filme);

            return new FilmeResult(filme);
        }

        public int? Excluir(int id)
        {
            var filme = _filmeRespositorio.ObterPorId(id);

            if (filme is null)
                _notificationContext.AddNotification($"Id: {id}", Resources.FilmeComIdInexistente);

            if (_notificationContext.HasNotifications)
                return default;

            _filmeRespositorio.Excluir(filme);

            return _unitOfWork.Commit();
        }
    }
}