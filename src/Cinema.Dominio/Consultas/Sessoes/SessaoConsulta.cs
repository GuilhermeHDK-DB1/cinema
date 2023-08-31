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

        public IEnumerable<ResumoDeSessaoResult> ConsultaDeSessoesDoDia(string data)
        {
            DateTime dateTime = Convert.ToDateTime(data);

            var listaDeSessoesResponse = new List<ResumoDeSessaoResult>();

            var sessoes = _sessaoRepositorio.ObterSessoesDoDia(dateTime);

            foreach (var sessao in sessoes)
                listaDeSessoesResponse.Add(new ResumoDeSessaoResult(sessao));

            return listaDeSessoesResponse;
        }

        public IEnumerable<SessaoResult> ConsultaDeSessoesEmSala3D()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SessaoResult> ConsultaDeSessoesEmSalaVip()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SessaoResult> ConsultaDeSessoesNaoIniciadasDoDia()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SessaoResult> ConsultaDeSessoesPorFilme(int filmeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SessaoResult> ConsultaDeSessoesPorHorario(DateTime horario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SessaoResult> ConsultaDeSessoesPorIdioma(int idioma)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SessaoResult> ConsultaDeSessoesPorSala(int salaId)
        {
            throw new NotImplementedException();
        }
    }
}
