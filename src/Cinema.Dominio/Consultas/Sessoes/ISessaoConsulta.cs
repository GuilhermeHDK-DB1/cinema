using Cinema.Dominio.Dtos.Filmes;
using Cinema.Dominio.Dtos.Sessoes;

namespace Cinema.Dominio.Consultas.Sessoes
{
    public interface ISessaoConsulta
    {
        SessaoResult ConsultaDeSessaoPorChave(int filmeId, int salaId, DateTime horario);
        IEnumerable<SessaoResult> ConsultaPaginadaDeSessoes(int skip, int take);
        IEnumerable<SessaoResult> ConsultaDeSessoesPorFilme(int filmeId);
        IEnumerable<SessaoResult> ConsultaDeSessoesPorSala(int salaId);
        IEnumerable<SessaoResult> ConsultaDeSessoesPorHorario(DateTime horario);
        IEnumerable<SessaoResult> ConsultaDeSessoesPorIdioma(DateTime horario);
        IEnumerable<SessaoResult> ConsultaDeSessoesDoDia();
        IEnumerable<SessaoResult> ConsultaDeSessoesNaoIniciadasDoDia();
        IEnumerable<SessaoResult> ConsultaDeSessoesEmSalaVip();
        IEnumerable<SessaoResult> ConsultaDeSessoesEmSala3D();
    }
}
