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

        public GeneroResult ConsultaDeGeneroPorId(int id)
        {
            var genero = _generoRepositorio.ObterPorId(id);

            return genero is not null ? new GeneroResult(genero) : null;
        }

        public IEnumerable<GeneroResult> ConsultaPaginadaDeGeneros(int skip, int take)
        {
            var listaDeGenerosResponse = new List<GeneroResult>();

            var generos = _generoRepositorio.ObterTodos();

            foreach (var genero in generos)
                listaDeGenerosResponse.Add(new GeneroResult(genero));

            return listaDeGenerosResponse.Skip(skip).Take(take);
        }
    }
}
