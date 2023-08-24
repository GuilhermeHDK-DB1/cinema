using Cinema.Dominio.Dtos.Generos;

namespace Cinema.Dominio.Consultas
{
    public interface IGeneroConsulta
    {
        GeneroReadDto ConsultaDeGeneroPorId(int id);

        //obterpaginado
        //obter por id
        //ObterTodos
        IEnumerable<GeneroReadDto> ConsultaPaginadaDeGeneros(int skip, int take);
    }
}
