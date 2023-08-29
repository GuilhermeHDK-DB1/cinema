using Cinema.Dominio.Common.Notifications;
using Cinema.Dominio.Common;
using Cinema.Dominio.Dtos.Salas;
using Cinema.Dominio.Entities.Salas;

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

        public SalaResult Atualizar(AtualizarSalaCommand salaDto)
        {
            var sala = _salaRepositorio.ObterPorId(salaDto.Id);

            var salaJaSalva = _salaRepositorio.ObterPeloNome(salaDto.Nome);

            if (sala is null)
                _notificationContext.AddNotification($"Id: {salaDto.Id}", Resources.SalaComIdInexistente);

            if (salaJaSalva is not null)
                _notificationContext.AddNotification($"Nome: {salaDto.Nome}", Resources.SalaComMesmoNomeJaExiste);

            if (_notificationContext.HasNotifications)
                return default;

            sala.AtualizarNome(salaDto.Nome);
            sala.AtualizarSalaVip(salaDto.SalaVip);
            sala.AtualizarSala3D(salaDto.Sala3D);
            sala.AtualizarCapacidade(salaDto.Capacidade);

            _salaRepositorio.Atualizar(sala);

            return new SalaResult(sala);
        }
    }
}
