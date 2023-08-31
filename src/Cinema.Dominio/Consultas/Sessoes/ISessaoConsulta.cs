using Cinema.Dominio.Dtos.Sessoes;

namespace Cinema.Dominio.Consultas.Sessoes
{
    public interface ISessaoConsulta
    {
        ResumoDeSessaoResult ConsultaDeSessaoPorId(int id);
        IEnumerable<SessaoResult> ConsultaPaginadaDeSessoes(int skip, int take);
        IEnumerable<ResumoDeSessaoResult> ConsultaDeSessoesPelaData(string data);
        IEnumerable<ResumoDeSessaoResult> ConsultaDeSessoesNaoIniciadasPorFilmeEData(int filmeId, string data);
        IEnumerable<ResumoDeSessaoResult> ConsultaDeSessoesNaoIniciadasPorHorario(DateTime horario);
        IEnumerable<SessaoResult> ConsultaDeSessoesNaoIniciadasDoDia();

        //IEnumerable<SessaoResult> ConsultaDeSessoesPorSala(int salaId);
        //IEnumerable<SessaoResult> ConsultaDeSessoesPorIdioma(int idioma);
        //IEnumerable<SessaoResult> ConsultaDeSessoesDoDiaEmSalaVip(string data);
        //IEnumerable<SessaoResult> ConsultaDeSessoesDoDiaEmSala3D(string data);
    }
}
