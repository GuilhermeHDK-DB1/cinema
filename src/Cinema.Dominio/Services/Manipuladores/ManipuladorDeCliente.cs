using Cinema.Dominio.Common.Notifications;
using Cinema.Dominio.Common;
using Cinema.Dominio.Dtos.Clientes;
using Cinema.Dominio.Entities.Clientes;

namespace Cinema.Dominio.Services.Manipuladores
{
    public class ManipuladorDeCliente
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly NotificationContext _notificationContext;

        public ManipuladorDeCliente(IClienteRepositorio clienteRepositorio, IUnitOfWork unitOfWork, NotificationContext notificationContext)
        {
            _clienteRepositorio = clienteRepositorio;
            _unitOfWork = unitOfWork;
            _notificationContext = notificationContext;
        }

        public ClienteResult Adicionar(CadastrarClienteCommand clienteDto)
        {
            var clienteComMesmoCpf = _clienteRepositorio.ObterPeloCpf(clienteDto.Cpf);
            var clienteComMesmoEmail = _clienteRepositorio.ObterPeloEmail(clienteDto.Email);

            if (clienteComMesmoCpf is not null)
                _notificationContext.AddNotification($"CPF: {clienteDto.Cpf}", Resources.ClienteComMesmoCpfJaExiste);
            if (clienteComMesmoEmail is not null)
                _notificationContext.AddNotification($"Email: {clienteDto.Email}", Resources.ClienteComMesmoEmailJaExiste);
            if (_notificationContext.HasNotifications)
                return default;

            DateTime data = Convert.ToDateTime(clienteDto.DataDeNascimento);

            var cliente = new Cliente(
                nome: clienteDto.Nome,
                cpf: clienteDto.Cpf,
                email: clienteDto.Email,
                dataDeNascimento: data);

            _clienteRepositorio.Adicionar(cliente);

            _unitOfWork.Commit();

            return new ClienteResult(cliente);
        }
    }
}
