using Cinema.Dominio.Dtos.Salas;

namespace Cinema.Dominio.Consultas.Salas
{
    public interface ISalaConsulta
    {
        SalaResult ConsultaDeSalaPorId(int id);
        IEnumerable<SalaResult> ConsultaPaginadaDeSalas(int skip, int take);
        IEnumerable<SalaResult> ConsultaDeSalasVip();
        IEnumerable<SalaResult> ConsultaDeSalas3D();
        IEnumerable<SalaResult> ConsultaDeSalasComCapacidadeDisponiveis();
    }
}
