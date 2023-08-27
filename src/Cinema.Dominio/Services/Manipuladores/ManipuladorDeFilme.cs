using Cinema.Dominio.Dtos.Filmes;

namespace Cinema.Dominio.Services.Manipuladores
{
    public class ManipuladorDeFilme
    {
        private readonly IFilmeRepositorio _filmeRespositorio;

        public ManipuladorDeFilme(IFilmeRepositorio filmeRepositorio)
        {
            _filmeRespositorio = filmeRepositorio;
        }

        
    }
}
