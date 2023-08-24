using Cinema.Dominio.Dtos.Generos;
using Cinema.Dominio.Services;

namespace Cinema.Dominio.Consultas
{
    public class GeneroConsulta : IGeneroConsulta
    {
        private readonly IGeneroRepositorio _generoRepositorio;

        public GeneroConsulta(IGeneroRepositorio generoRepositorio)
        {
            _generoRepositorio = generoRepositorio;
        }

        public IEnumerable<GeneroReadDto> ConsultaPaginadaDeGeneros(int skip, int take)
        {
            var listaDeGenerosResponse = new List<GeneroReadDto>();

            var generos = _generoRepositorio.ObterTodos();

            foreach (var genero in generos)
                listaDeGenerosResponse.Add(new GeneroReadDto(genero));

            return listaDeGenerosResponse.Skip(skip).Take(take);
        }
    }
}
