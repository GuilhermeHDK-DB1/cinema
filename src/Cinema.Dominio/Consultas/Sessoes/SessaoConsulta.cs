using Cinema.Dominio.Dtos.Sessoes;
using Cinema.Dominio.Services;

namespace Cinema.Dominio.Consultas.Sessoes
{
    public class SessaoConsulta : ISessaoConsulta
    {
        private readonly ISessaoRepositorio _sessaoRepositorio;
        public SessaoConsulta(ISessaoRepositorio sessaoRepositorio)
        {
            _sessaoRepositorio = sessaoRepositorio;
        }

        public ResumoDeSessaoResult ConsultaDeSessaoPorId(int id)
        {
            var sessao = _sessaoRepositorio.ObterPorId(id);

            return sessao is not null ? new ResumoDeSessaoResult(sessao) : null;
        }

        public IEnumerable<SessaoResult> ConsultaPaginadaDeSessoes(int skip, int take)
        {
            var listaDeSessoesResponse = new List<SessaoResult>();

            var sessoes = _sessaoRepositorio.ObterPaginado(skip, take);

            foreach (var sessao in sessoes)
                listaDeSessoesResponse.Add(new SessaoResult(sessao));

            return listaDeSessoesResponse;
        }

        public IEnumerable<ResumoDeSessaoResult> ConsultaDeSessoesPelaData(string data)
        {
            DateTime datetime = Convert.ToDateTime(data);

            var listaDeSessoesResponse = new List<ResumoDeSessaoResult>();

            var sessoes = _sessaoRepositorio.ObterSessoesPelaData(datetime);

            foreach (var sessao in sessoes)
                listaDeSessoesResponse.Add(new ResumoDeSessaoResult(sessao));

            return listaDeSessoesResponse;
        }

        public IEnumerable<ResumoDeSessaoResult> ConsultaDeSessoesNaoIniciadasPorFilmeEData(int filmeId, string data)
        {
            DateTime datetime = Convert.ToDateTime(data);

            var listaDeSessoesResponse = new List<ResumoDeSessaoResult>();

            var sessoes = _sessaoRepositorio.ObterSessoesNaoIniciadasPorFilmeEData(filmeId, datetime);

            foreach (var sessao in sessoes)
                listaDeSessoesResponse.Add(new ResumoDeSessaoResult(sessao));

            return listaDeSessoesResponse;
        }

        public IEnumerable<ResumoDeSessaoResult> ConsultaDeSessoesNaoIniciadasPorHorario(DateTime horario)
        {
            var listaDeSessoesResponse = new List<ResumoDeSessaoResult>();
            var sessoes = _sessaoRepositorio.ObterSessoesNaoIniciadasPorHorario(horario);

            foreach (var sessao in sessoes)
                listaDeSessoesResponse.Add(new ResumoDeSessaoResult(sessao));

            return listaDeSessoesResponse;
        }

        public IEnumerable<ResumoDeSessaoResult> ConsultaDeSessoesNaoIniciadasDoDia()
        {
            var listaDeSessoesResponse = new List<ResumoDeSessaoResult>();
            var sessoes = _sessaoRepositorio.ObterSessoesNaoIniciadasDoDia();

            foreach (var sessao in sessoes)
                listaDeSessoesResponse.Add(new ResumoDeSessaoResult(sessao));

            return listaDeSessoesResponse;
        }
    }
}
