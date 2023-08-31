using Cinema.Dominio.Dtos.Filmes;
using Cinema.Dominio.Dtos.Sessoes;

namespace Cinema.Dominio.Consultas.Sessoes
{
    public interface ISessaoConsulta
    {
        ResumoDeSessaoResult ConsultaDeSessaoPorId(int id);
        IEnumerable<SessaoResult> ConsultaPaginadaDeSessoes(int skip, int take);
        IEnumerable<SessaoResult> ConsultaDeSessoesPorFilme(int filmeId);
        IEnumerable<SessaoResult> ConsultaDeSessoesPorSala(int salaId);
        IEnumerable<SessaoResult> ConsultaDeSessoesPorHorario(DateTime horario);
        IEnumerable<SessaoResult> ConsultaDeSessoesPorIdioma(int idioma);
        IEnumerable<ResumoDeSessaoResult> ConsultaDeSessoesDoDia(string data);
        IEnumerable<SessaoResult> ConsultaDeSessoesNaoIniciadasDoDia();
        IEnumerable<SessaoResult> ConsultaDeSessoesEmSalaVip();
        IEnumerable<SessaoResult> ConsultaDeSessoesEmSala3D();
    }
}
