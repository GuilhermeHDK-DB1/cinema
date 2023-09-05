using Cinema.Dominio.Common.Notifications;
using Cinema.Dominio.Common;
using Cinema.Dominio.Dtos.Ingressos;
using Cinema.Dominio.Entities.Ingressos;

namespace Cinema.Dominio.Services.Manipuladores
{
    public class ManipuladorDeIngresso
    {
        private readonly IIngressoRepositorio _ingressoRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly ISessaoRepositorio _sessaoRepositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly NotificationContext _notificationContext;

        public ManipuladorDeIngresso(IIngressoRepositorio ingressoRepositorio, IClienteRepositorio clienteRepositorio, ISessaoRepositorio sessaoRepositorio, IUnitOfWork unitOfWork, NotificationContext notificationContext)
        {
            _ingressoRepositorio = ingressoRepositorio;
            _clienteRepositorio = clienteRepositorio;
            _sessaoRepositorio = sessaoRepositorio;
            _unitOfWork = unitOfWork;
            _notificationContext = notificationContext;
        }

        public IngressoResult Adicionar(CadastrarIngressoCommand ingressoDto)
        {
            var cliente = _clienteRepositorio.ObterPorId(ingressoDto.ClienteId);
            var sessao = _sessaoRepositorio.ObterPorId(ingressoDto.SessaoId);
            
            //validar quantidade disponivel

            //se capacidade > 0

            if (cliente is null)
                _notificationContext.AddNotification($"ClienteId: {ingressoDto.ClienteId}", Resources.ClienteComIdInexistente);
            if (sessao is null)
                _notificationContext.AddNotification($"SessaoId: {ingressoDto.SessaoId}", Resources.SessaoComIdInexistente);
            if (_notificationContext.HasNotifications)
                return default;

            var ingresso = new Ingresso(
                cliente: cliente,
                sessao: sessao,
                tipo: ingressoDto.Tipo);

            _ingressoRepositorio.Adicionar(ingresso);

            _unitOfWork.Commit();

            return new IngressoResult(ingresso);
        }
    }
}
