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

            var sala = _salaRepositorio.ObterPorId(sessaoDto.SalaId);

            DateTime horario = Convert.ToDateTime(sessaoDto.Horario);

            var sessaoJaSalva = _sessaoRepositorio.ObterPelaSalaEHorario(sessaoDto.SalaId, horario);

            if (filme is null)
                _notificationContext.AddNotification($"FilmeId: {sessaoDto.FilmeId}", Resources.FilmeComIdInexistente);
            if (sala is null)
                _notificationContext.AddNotification($"SalaId: {sessaoDto.SalaId}", Resources.SalaComIdInexistente);
            if (sessaoJaSalva is not null)
                _notificationContext.AddNotification(
                    $"SalaId: {sessaoDto.SalaId}, " +
                    $"Horario: {sessaoDto.Horario}", 
                    Resources.SessaoComMesmosDadosJaExiste);

            if (_notificationContext.HasNotifications)
                return default;
            // validação de horários para 10:00:00, 13:00:00, 16:00:00, 19:00:00, 22:00:00

            var sessao = new Sessao(
                filme: filme,
                sala: sala,
                horario: horario,
                idioma: sessaoDto.Idioma);

            _sessaoRepositorio.Adicionar(sessao);

            _unitOfWork.Commit();

            return new SessaoResult(sessao);
        }

        public SessaoResult Atualizar(AtualizarSessaoCommand sessaoDto)
        {
            var sessao = _sessaoRepositorio.ObterPorId(sessaoDto.Id);

            var filme = _filmeRepositorio.ObterPorId(sessaoDto.FilmeId);

            var sala = _salaRepositorio.ObterPorId(sessaoDto.SalaId);

            DateTime horario = Convert.ToDateTime(sessaoDto.Horario);

            var sessaoJaSalva = _sessaoRepositorio.ObterPelaSalaEHorario(sessaoDto.SalaId, horario);

            if (sessao is null)
                _notificationContext.AddNotification($"Id: {sessaoDto.Id}", Resources.SessaoComIdInexistente);
            if (filme is null)
                _notificationContext.AddNotification($"FilmeId: {sessaoDto.FilmeId}", Resources.FilmeComIdInexistente);
            if (sala is null)
                _notificationContext.AddNotification($"SalaId: {sessaoDto.SalaId}", Resources.SalaComIdInexistente);
            if (sessaoJaSalva is not null && sessaoJaSalva.Id != sessaoDto.Id)
                _notificationContext.AddNotification(
                    $"SalaId: {sessaoDto.SalaId}, " +
                    $"Horario: {sessaoDto.Horario}",
                    Resources.SessaoComMesmosDadosJaExiste);
            if (_notificationContext.HasNotifications)
                return default;

            sessao.AlterarFilme(filme);
            sessao.AlterarSala(sala);
            sessao.AlterarHorario(horario);
            sessao.AlterarIdioma(sessaoDto.Idioma);

            _sessaoRepositorio.Atualizar(sessao);

            return new SessaoResult(sessao);
        }

        public int Excluir(int id)
        {
            var sessao = _sessaoRepositorio.ObterPorId(id);

            if (sessao is null)
                _notificationContext.AddNotification($"Id: {id}", Resources.SessaoComIdInexistente);

            if (_notificationContext.HasNotifications)
                return default;

            _sessaoRepositorio.Excluir(sessao);

            return _unitOfWork.Commit();
        }
    }
}
