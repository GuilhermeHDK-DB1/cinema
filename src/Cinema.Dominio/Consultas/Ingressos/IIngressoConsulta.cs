using Cinema.Dominio.Dtos.Ingressos;

namespace Cinema.Dominio.Consultas.Ingressos
{
    public interface IIngressoConsulta
    {
        IEnumerable<IngressoResult> ConsultaPaginadaDeIngressos(int skip, int take);
    }
}
