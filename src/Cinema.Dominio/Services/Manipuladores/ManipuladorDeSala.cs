using Cinema.Dominio.Common.Notifications;
using Cinema.Dominio.Common;
using Cinema.Dominio.Dtos.Salas;
using Cinema.Dominio.Entities.Salas;
using Cinema.Dominio.Dtos.Filmes;
using Cinema.Dominio.Entities.Filmes;

namespace Cinema.Dominio.Services.Manipuladores
{
    public class ManipuladorDeSala
    {
        private readonly ISalaRepositorio _salaRepositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly NotificationContext _notificationContext;

        public ManipuladorDeSala(ISalaRepositorio salaRepositorio, IUnitOfWork unitOfWork, NotificationContext notificationContext)
        {
            _salaRepositorio = salaRepositorio;
            _unitOfWork = unitOfWork;
            _notificationContext = notificationContext;
        }

        public SalaResult adicionar(CadastrarSalaCommand salaDto)
        {
            var salaJaSalva = _salaRepositorio.ObterPeloNome(salaDto.Nome);

            if (salaJaSalva is not null)
                _notificationContext.AddNotification($"Nome: {salaDto.Nome}", Resources.SalaComMesmoNomeJaExiste);

            if (_notificationContext.HasNotifications)
                return default;

            var sala = new Sala
            {
                Nome = salaDto.Nome,
                SalaVip = salaDto.SalaVip,
                Sala3D = salaDto.Sala3D,
                Capacidade = salaDto.Capacidade
            };

            _salaRepositorio.Adicionar(sala);

            _unitOfWork.Commit();

            return new SalaResult(sala);
        }


    }
}
