using Cinema.Dominio.Common.Notifications;
using Cinema.Dominio.Common;
using Cinema.Dominio.Dtos.Sessoes;
using Cinema.Dominio.Entities.Sessoes;

namespace Cinema.Dominio.Services.Manipuladores
{
    public class ManipuladorDeSessao
    {
        ISessaoRepositorio _sessaoRepositorio;
        IFilmeRepositorio _filmeRepositorio;
        ISalaRepositorio _salaRepositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly NotificationContext _notificationContext;

        public ManipuladorDeSessao(ISessaoRepositorio sessaoRepositorio, IFilmeRepositorio filmeRepositorio, ISalaRepositorio salaRepositorio, IUnitOfWork unitOfWork, NotificationContext notificationContext)
        {
            _sessaoRepositorio = sessaoRepositorio;
            _filmeRepositorio = filmeRepositorio;
            _salaRepositorio = salaRepositorio;
            _unitOfWork = unitOfWork;
            _notificationContext = notificationContext;
        }

        public SessaoResult Adicionar(CadastrarSessaoCommand sessaoDto)
        {
            var filme = _filmeRepositorio.ObterPorId(sessaoDto.FilmeId);
            if (filme is null)
                _notificationContext.AddNotification($"FilmeId: {sessaoDto.FilmeId}", Resources.FilmeComIdInexistente);

            var sala = _salaRepositorio.ObterPorId(sessaoDto.SalaId);
            if (sala is null)
                _notificationContext.AddNotification($"SalaId: {sessaoDto.SalaId}", Resources.SalaComIdInexistente);

            DateTime horario = Convert.ToDateTime(sessaoDto.Horario);

            var sessaoJaSalva = _sessaoRepositorio.ObterPelaSalaEHorario(sessaoDto.SalaId, horario);
            if (sessaoJaSalva is not null)
                _notificationContext.AddNotification(
                    $"SalaId: {sessaoDto.SalaId}, " +
                    $"Horario: {sessaoDto.Horario}", 
                    Resources.SessaoComMesmosDadosJaExiste);

            // validação de horários para 10:00:00, 13:00:00, 16:00:00, 19:00:00, 22:00:00

            if (_notificationContext.HasNotifications)
                return default;

            var sessao = new Sessao(
                filme: filme,
                sala: sala,
                horario: horario,
                idioma: sessaoDto.Idioma);

            _sessaoRepositorio.Adicionar(sessao);

            _unitOfWork.Commit();

            return new SessaoResult(sessao);
        }
    }
}
