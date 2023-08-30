using Cinema.Dominio.Dtos.Filmes;
using Cinema.Dominio.Services;

namespace Cinema.Dominio.Consultas.Filmes
{
    public class FilmeConsulta : IFilmeConsulta
    {
        private IFilmeRepositorio _filmeRepositorio;

        public FilmeConsulta(IFilmeRepositorio filmeRepositorio)
        {
            _filmeRepositorio = filmeRepositorio;
        }

        public FilmeResult ConsultaDeFilmePorId(int id)
        {
            var filme = _filmeRepositorio.ObterPorId(id);

            return filme is not null ? new FilmeResult(filme) : null;
        }

        public IEnumerable<FilmeResult> ConsultaDeFilmesPorClassificacao(string classificacao)
        {
            var listaDeFilmesResponse = new List<FilmeResult>();

            var filmes = _filmeRepositorio.ObterPelaClassificacao(classificacao);

            foreach (var filme in filmes)
                listaDeFilmesResponse.Add(new FilmeResult(filme));

            return listaDeFilmesResponse;
        }

        public IEnumerable<FilmeResult> ConsultaDeFilmesPorGenero(string genero)
        {
            var listaDeFilmesResponse = new List<FilmeResult>();

            var filmes = _filmeRepositorio.ObterPorGenero(genero);

            foreach (var filme in filmes)
                listaDeFilmesResponse.Add(new FilmeResult(filme));

            return listaDeFilmesResponse;
        }

        public IEnumerable<FilmeResult> ConsultaPaginadaDeFilmes(int skip, int take)
        {
            var listaDeFilmesResponse = new List<FilmeResult>();

            var filmes = _filmeRepositorio.ObterPaginado(skip, take);

            foreach (var filme in filmes)
                listaDeFilmesResponse.Add(new FilmeResult(filme));

            return listaDeFilmesResponse;
        }

        public IEnumerable<FilmeResult> ConsultaDeFilmesDoDia()
        {
            var listaDeFilmesResponse = new List<FilmeResult>();

            var filmes = _filmeRepositorio.ObterFilmesDoDia();

            foreach (var filme in filmes)
                listaDeFilmesResponse.Add(new FilmeResult(filme));

            return listaDeFilmesResponse;
        }

        public IEnumerable<FilmeResult> ConsultaDeFilmesDoDiaNaoIniciados()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FilmeResult> ConsultaDeFilmesEm3D()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FilmeResult> ConsultaDeFilmesEmSalaVip()
        {
            throw new NotImplementedException();
        }
    }
}
