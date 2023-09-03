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

        public IEnumerable<IngressoResult> ConsultaPaginadaDeIngressos(int skip, int take)
        {
            var listaDeIngressosResponse = new List<IngressoResult>();

            var ingressos = _ingressoRepositorio.ObterPaginado(skip, take);

            foreach (var ingresso in ingressos)
                listaDeIngressosResponse.Add(new IngressoResult(ingresso));

            return listaDeIngressosResponse;
        }
    }
}
