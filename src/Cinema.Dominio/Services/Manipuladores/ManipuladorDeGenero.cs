using Cinema.Dominio.Common;
using Cinema.Dominio.Common.Notifications;
using Cinema.Dominio.Dtos.Generos;
using Cinema.Dominio.Entities.Filmes;
using Cinema.Dominio.Entities.Generos;

namespace Cinema.Dominio.Services.Manipuladores
{
    public class ManipuladorDeGenero
    {
        private readonly IGeneroRepositorio _generoRepositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly NotificationContext _notificationContext;

        public ManipuladorDeGenero(IGeneroRepositorio generoRepositorio, IUnitOfWork unitOfWork, NotificationContext notificationContext)
        {
            _generoRepositorio = generoRepositorio;
            _unitOfWork = unitOfWork;
            _notificationContext = notificationContext;
        }

        public GeneroResult Adicionar(CadastrarGeneroCommand generoDto)
        {
            var generoJaSalvo = _generoRepositorio.ObterPeloNome(generoDto.Nome);

            if (generoJaSalvo is not null)
                _notificationContext.AddNotification($"Genero: {generoDto.Nome}", Resources.GeneroComMesmoNomeJaExiste);

            if (_notificationContext.HasNotifications)
                return default;

            //ValidadorDeRegra.Novo()
            //    .Quando(generoJaSalvo != null, Resources.GeneroComMesmoNomeJaExiste)
            //    .DispararExcecaoSeExistir();

            var genero = new Genero(generoDto.Nome);
            _generoRepositorio.Adicionar(genero);

            _unitOfWork.Commit();

            return new GeneroResult(genero);
        }

        public GeneroResult Atualizar(AtualizarGeneroCommand generoDto)
        {
            var genero = _generoRepositorio.ObterPorId(generoDto.Id);

            var generoJaSalvo = _generoRepositorio.ObterPeloNome(generoDto.Nome);

            if (genero is null)
                _notificationContext.AddNotification($"Id: {generoDto.Id}", Resources.GeneroComIdInexistente);

            if (generoJaSalvo != null &&
                generoJaSalvo.Nome.Contains(generoDto.Nome) &&
                generoJaSalvo.Id != genero.Id)
                _notificationContext.AddNotification($"Genero: {generoDto.Nome}", Resources.GeneroComMesmoNomeJaExiste);

            if (_notificationContext.HasNotifications)
                return default;

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