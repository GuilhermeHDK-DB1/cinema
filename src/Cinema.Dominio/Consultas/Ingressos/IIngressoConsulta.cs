using Cinema.Dominio.Dtos.Ingressos;

namespace Cinema.Dominio.Consultas.Ingressos
{
    public interface IIngressoConsulta
    {
        ResumoDeIngressoResult ConsultaDeIngressoPorId(int id);
        IEnumerable<IngressoResult> ConsultaPaginadaDeIngressos(int skip, int take);
        IEnumerable<ResumoDeIngressoResult> ConsultaDeIngressosPeloClienteId(int clienteId);
        IEnumerable<ResumoDeIngressoResult> ConsultaDeIngressosPeloSessaoId(int sessaoId);
        QuantidadeDeIngressosVendidosResult ConsultaDeQuantidadeDeIngressosVendidosPeloSessaoId(int sessaoId);
        QuantidadeDeIngressoDisponiveisResult ConsultaDeQuantidadeDeIngressosDisponiveisPeloSessaoId(int sessaoId);
    }
}
