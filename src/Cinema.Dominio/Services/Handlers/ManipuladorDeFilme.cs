using Cinema.Dominio.Dtos.Filme;

namespace Cinema.Dominio.Services.Handlers
{
    public class ManipuladorDeFilme
    {
        private readonly IFilmeRepositorio _filmeRespositorio;

        public ManipuladorDeFilme(IFilmeRepositorio filmeRepositorio)
        {
            _filmeRespositorio = filmeRepositorio;
        }

        public FilmeReadDto ObterFilmesDoDia()
        {
            throw new NotImplementedException();
        }

        public FilmeReadDto ObterFilmesDoDiaNaoIniciados()
        {
            throw new NotImplementedException();
        }

        public FilmeReadDto ObterFilmesEmSalaVip()
        {
            throw new NotImplementedException();
        }

        public FilmeReadDto ObterFilmesEm3D()
        {
            throw new NotImplementedException();
        }
    }
}
