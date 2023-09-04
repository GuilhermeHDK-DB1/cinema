using Cinema.Dominio.Dtos.Ingressos;
using Cinema.Dominio.Services;

namespace Cinema.Dominio.Consultas.Ingressos
{
    public class IngressoConsulta : IIngressoConsulta
    {
        private readonly IIngressoRepositorio _ingressoRepositorio;

        public IngressoConsulta(IIngressoRepositorio ingressoRepositorio)
        {
            _ingressoRepositorio = ingressoRepositorio;
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
    }
}
