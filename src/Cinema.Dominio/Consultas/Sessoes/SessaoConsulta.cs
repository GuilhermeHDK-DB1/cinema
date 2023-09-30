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

        public ResumoDeSessaoResult? ConsultaDeSessaoPorId(int id)
        {
            var sessao = _sessaoRepositorio.ObterPorId(id);

            return sessao is null ? null :
                new ResumoDeSessaoResult()
                {
                    Id = sessao.Id,
                    NomeDoFilme = sessao.Filme.Nome,
                    Duracao = sessao.Filme.Duracao,
                    Classificacao = sessao.Filme.ClassificacaoString,
                    Genero = sessao.Filme.Genero.Nome,
                    Horario = sessao.Horario,
                    NomeDaSala = sessao.Sala.Nome,
                    SalaVip = sessao.Sala.SalaVip,
                    Sala3D = sessao.Sala.Sala3D,
                    CapacidadeDisponivel = sessao.Sala.Capacidade - sessao.Ingressos.Count
                };
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
                listaDeSessoesResponse.Add(
                    new ResumoDeSessaoResult()
                    {
                        Id = sessao.Id,
                        NomeDoFilme = sessao.Filme.Nome,
                        Duracao = sessao.Filme.Duracao,
                        Classificacao = sessao.Filme.ClassificacaoString,
                        Genero = sessao.Filme.Genero.Nome,
                        Horario = sessao.Horario,
                        NomeDaSala = sessao.Sala.Nome,
                        SalaVip = sessao.Sala.SalaVip,
                        Sala3D = sessao.Sala.Sala3D,
                        CapacidadeDisponivel = sessao.Sala.Capacidade - sessao.Ingressos.Count
                    });

            return listaDeSessoesResponse;
        }

        public IEnumerable<ResumoDeSessaoResult> ConsultaDeSessoesNaoIniciadasPorFilmeEData(int filmeId, string data)
        {
            DateTime datetime = Convert.ToDateTime(data);

            var listaDeSessoesResponse = new List<ResumoDeSessaoResult>();

            var sessoes = _sessaoRepositorio.ObterSessoesNaoIniciadasPorFilmeEData(filmeId, datetime);

            foreach (var sessao in sessoes)
                listaDeSessoesResponse.Add(
                    new ResumoDeSessaoResult()
                    {
                        Id = sessao.Id,
                        NomeDoFilme = sessao.Filme.Nome,
                        Duracao = sessao.Filme.Duracao,
                        Classificacao = sessao.Filme.ClassificacaoString,
                        Genero = sessao.Filme.Genero.Nome,
                        Horario = sessao.Horario,
                        NomeDaSala = sessao.Sala.Nome,
                        SalaVip = sessao.Sala.SalaVip,
                        Sala3D = sessao.Sala.Sala3D,
                        CapacidadeDisponivel = sessao.Sala.Capacidade - sessao.Ingressos.Count
                    });

            return listaDeSessoesResponse;
        }

        public IEnumerable<ResumoDeSessaoResult> ConsultaDeSessoesNaoIniciadasPorHorario(string horario)
        {
            DateTime datetime = Convert.ToDateTime(horario);

            var listaDeSessoesResponse = new List<ResumoDeSessaoResult>();
            var sessoes = _sessaoRepositorio.ObterSessoesNaoIniciadasPorHorario(datetime);

            foreach (var sessao in sessoes)
                listaDeSessoesResponse.Add(
                    new ResumoDeSessaoResult()
                    {
                        Id = sessao.Id,
                        NomeDoFilme = sessao.Filme.Nome,
                        Duracao = sessao.Filme.Duracao,
                        Classificacao = sessao.Filme.ClassificacaoString,
                        Genero = sessao.Filme.Genero.Nome,
                        Horario = sessao.Horario,
                        NomeDaSala = sessao.Sala.Nome,
                        SalaVip = sessao.Sala.SalaVip,
                        Sala3D = sessao.Sala.Sala3D,
                        CapacidadeDisponivel = sessao.Sala.Capacidade - sessao.Ingressos.Count
                    });

            return listaDeSessoesResponse;
        }

        public IEnumerable<ResumoDeSessaoResult> ConsultaDeSessoesNaoIniciadasDoDia()
        {
            var listaDeSessoesResponse = new List<ResumoDeSessaoResult>();
            var sessoes = _sessaoRepositorio.ObterSessoesNaoIniciadasDoDia();

            foreach (var sessao in sessoes)
                listaDeSessoesResponse.Add(
                    new ResumoDeSessaoResult()
                    {
                        Id = sessao.Id,
                        NomeDoFilme = sessao.Filme.Nome,
                        Duracao = sessao.Filme.Duracao,
                        Classificacao = sessao.Filme.ClassificacaoString,
                        Genero = sessao.Filme.Genero.Nome,
                        Horario = sessao.Horario,
                        NomeDaSala = sessao.Sala.Nome,
                        SalaVip = sessao.Sala.SalaVip,
                        Sala3D = sessao.Sala.Sala3D,
                        CapacidadeDisponivel = sessao.Sala.Capacidade - sessao.Ingressos.Count
                    });

            return listaDeSessoesResponse;
        }
    }
}
