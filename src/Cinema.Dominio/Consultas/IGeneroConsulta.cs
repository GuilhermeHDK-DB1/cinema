using Cinema.Dominio.Dtos.Generos;
using Cinema.Dominio.Services;

namespace Cinema.Dominio.Consultas
{
    public interface IGeneroConsulta
    {
        //obterpaginado
        //obter por id
        //ObterTodos
        IEnumerable<GeneroReadDto> ConsultaPaginadaDeGeneros(int skip, int take);
    }
}
