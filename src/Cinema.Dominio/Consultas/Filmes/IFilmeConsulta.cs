using Cinema.Dominio.Dtos.Filmes;

namespace Cinema.Dominio.Consultas.Filmes
{
    public interface IFilmeConsulta
    {
        FilmeResult ConsultaDeFilmePorId(int id);
        IEnumerable<FilmeResult> ConsultaDeFilmesPorDataDeLancamento(string dataDeLancamento);
        IEnumerable<FilmeResult> ConsultaDeFilmesPorClassificacao(string classificacao);
        IEnumerable<FilmeResult> ConsultaDeFilmesPorGenero(string genero);
        IEnumerable<FilmeResult> ConsultaPaginadaDeFilmes(int skip, int take);
        IEnumerable<FilmeResult> ConsultaDeFilmesDoDia();
        IEnumerable<FilmeResult> ConsultaDeFilmesDoDiaNaoIniciados();
        IEnumerable<FilmeResult> ConsultaDeFilmesEmSalaVip();
        IEnumerable<FilmeResult> ConsultaDeFilmesEm3D();
    }
}
