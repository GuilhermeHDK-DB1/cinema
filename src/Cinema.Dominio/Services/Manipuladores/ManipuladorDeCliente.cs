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
            var clienteComMesmoCpfJaSalvo = _clienteRepositorio.ObterPeloCpf(clienteDto.Cpf);
            var clienteComMesmoEmailJaSalvo = _clienteRepositorio.ObterPeloEmail(clienteDto.Email);

            if (clienteComMesmoCpfJaSalvo is not null)
                _notificationContext.AddNotification($"CPF: {clienteDto.Cpf}", Resources.ClienteComMesmoCpfJaExiste);
            if (clienteComMesmoEmailJaSalvo is not null)
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

        public ClienteResult Atualizar(AtualizarClienteCommand clienteDto)
        {
            var cliente = _clienteRepositorio.ObterPorId(clienteDto.Id);
            var clienteComMesmoCpfJaSalvo = _clienteRepositorio.ObterPeloCpf(clienteDto.Cpf);
            var clienteComMesmoEmailJaSalvo = _clienteRepositorio.ObterPeloEmail(clienteDto.Email);

            if (cliente is null)
                _notificationContext.AddNotification($"Id: {clienteDto.Id}", Resources.ClienteComIdInexistente);
            if (clienteComMesmoCpfJaSalvo is not null && clienteComMesmoCpfJaSalvo.Id != clienteDto.Id)
                _notificationContext.AddNotification($"CPF: {clienteDto.Cpf}", Resources.ClienteComMesmoCpfJaExiste);
            if (clienteComMesmoEmailJaSalvo is not null && clienteComMesmoEmailJaSalvo.Id != clienteDto.Id)
                _notificationContext.AddNotification($"Email: {clienteDto.Email}", Resources.ClienteComMesmoEmailJaExiste);
            if (_notificationContext.HasNotifications)
                return default;

            DateTime data = Convert.ToDateTime(clienteDto.DataDeNascimento);

            cliente.AlterarNome(clienteDto.Nome);
            cliente.AlterarDataDeNascimento(data);
            cliente.AlterarCpf(clienteDto.Cpf);
            cliente.AlterarEmail(clienteDto.Email);

            _clienteRepositorio.Atualizar(cliente);

            return new ClienteResult(cliente);
        }

        public int Desativar(int id)
        {
            var cliente = _clienteRepositorio.ObterPorId(id);

            if (cliente is null)
                _notificationContext.AddNotification($"Id: {id}", Resources.ClienteComIdInexistente);
            if (cliente is not null && !cliente.Ativo)
                _notificationContext.AddNotification($"Id: {id}", Resources.ClienteJaEstaInativo);
            if (_notificationContext.HasNotifications)
                return default;

            _clienteRepositorio.Desativar(cliente);

            return _unitOfWork.Commit();
        }

        public int Ativar(int id)
        {
            var cliente = _clienteRepositorio.ObterPorId(id);

            if (cliente is null)
                _notificationContext.AddNotification($"Id: {id}", Resources.ClienteComIdInexistente);
            if (cliente is not null && cliente.Ativo)
                _notificationContext.AddNotification($"Id: {id}", Resources.ClienteJaEstaAtivo);
            if (_notificationContext.HasNotifications)
                return default;

            _clienteRepositorio.Ativar(cliente);

            return _unitOfWork.Commit();
        }
    }
}
