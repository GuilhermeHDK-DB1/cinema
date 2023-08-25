using Cinema.Dominio.Dtos.Generos;

namespace Cinema.Dominio.Consultas
{
    public interface IGeneroConsulta
    {
        GeneroResult ConsultaDeGeneroPorId(int id);

        IEnumerable<GeneroResult> ConsultaPaginadaDeGeneros(int skip, int take);
    }
}
