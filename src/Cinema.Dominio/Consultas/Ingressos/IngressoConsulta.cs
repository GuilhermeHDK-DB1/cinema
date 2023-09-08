using Cinema.Dominio.Dtos.Ingressos;
using Cinema.Dominio.Services;

namespace Cinema.Dominio.Consultas.Ingressos
{
    public class IngressoConsulta : IIngressoConsulta
    {
        private readonly IIngressoRepositorio _ingressoRepositorio;
        private readonly ISessaoRepositorio _sessaoRepositorio;

        public IngressoConsulta(IIngressoRepositorio ingressoRepositorio, ISessaoRepositorio sessaoRepositorio)
        {
            _ingressoRepositorio = ingressoRepositorio;
            _sessaoRepositorio = sessaoRepositorio;
        }

        public ResumoDeIngressoResult ConsultaDeIngressoPorId(int id)
        {
            var ingresso = _ingressoRepositorio.ObterPorId(id);

            return ingresso is not null ? new ResumoDeIngressoResult(ingresso) : null;
        }

        public IEnumerable<IngressoResult> ConsultaPaginadaDeIngressos(int skip, int take)
        {
            var listaDeIngressosResponse = new List<IngressoResult>();

            var ingressos = _ingressoRepositorio.ObterPaginado(skip, take);

            foreach (var ingresso in ingressos)
                listaDeIngressosResponse.Add(new IngressoResult(ingresso));

            return listaDeIngressosResponse;
        }

        public IEnumerable<ResumoDeIngressoResult> ConsultaDeIngressosPeloClienteId(int clienteId)
        {
            var listaDeIngressosResponse = new List<ResumoDeIngressoResult>();

            var ingressos = _ingressoRepositorio.ObterIngressosPeloClienteId(clienteId);

            foreach (var ingresso in ingressos)
                listaDeIngressosResponse.Add(new ResumoDeIngressoResult(ingresso));

            return listaDeIngressosResponse;
        }

        public IEnumerable<ResumoDeIngressoResult> ConsultaDeIngressosPeloSessaoId(int sessaoId)
        {
            var listaDeIngressosResponse = new List<ResumoDeIngressoResult>();

            var ingressos = _ingressoRepositorio.ObterIngressosPeloSessaoId(sessaoId);

            foreach (var ingresso in ingressos)
                listaDeIngressosResponse.Add(new ResumoDeIngressoResult(ingresso));

            return listaDeIngressosResponse;
        }

        public QuantidadeDeIngressosVendidosResult ConsultaDeQuantidadeDeIngressosVendidosPeloSessaoId(int sessaoId)
        {
            var quantidadeDeIngresso = _ingressoRepositorio.ObterQuantidadeDeIngressosVendidosPeloSessaoId(sessaoId);

            return new QuantidadeDeIngressosVendidosResult(quantidadeDeIngresso);
        }

        public QuantidadeDeIngressoDisponiveisResult ConsultaDeQuantidadeDeIngressosDisponiveisPeloSessaoId(int sessaoId)
        {
            var quantidadeDeIngressosTotal = _sessaoRepositorio.ObterCapacidadeDaSalaPeloId(sessaoId);
            var quantidadeDeIngressosVendidos = _ingressoRepositorio.ObterQuantidadeDeIngressosVendidosPeloSessaoId(sessaoId);

            var quantidadeDeIngressosDisponiveis = quantidadeDeIngressosTotal - quantidadeDeIngressosVendidos;

            return new QuantidadeDeIngressoDisponiveisResult(quantidadeDeIngressosDisponiveis);
        }
    }
}
