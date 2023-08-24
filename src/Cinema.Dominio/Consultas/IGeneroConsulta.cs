using Cinema.Dominio.Dtos.Generos;

namespace Cinema.Dominio.Consultas
{
    public interface IGeneroConsulta
    {
        GeneroReadDto ConsultaDeGeneroPorId(int id);

        IEnumerable<GeneroReadDto> ConsultaPaginadaDeGeneros(int skip, int take);
    }
}
