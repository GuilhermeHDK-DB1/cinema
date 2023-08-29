using Cinema.Dominio.Dtos.Salas;
using Cinema.Dominio.Services;

namespace Cinema.Dominio.Consultas.Salas
{
    public class SalaConsulta : ISalaConsulta
    {
        private readonly ISalaRepositorio _salaRepositorio;

        public SalaConsulta(ISalaRepositorio salaRepositorio)
        {
            _salaRepositorio = salaRepositorio;
        }
        public SalaResult ConsultaDeSalaPorId(int id)
        {
            var sala = _salaRepositorio.ObterPorId(id);

            return sala is not null ? new SalaResult(sala) : null;
        }
        
        public IEnumerable<SalaResult> ConsultaPaginadaDeSalas(int skip, int take)
        {
            var listaDeSalasResponse = new List<SalaResult>();

            var salas = _salaRepositorio.ObterPaginado(skip, take);

            foreach (var sala in salas)
                listaDeSalasResponse.Add(new SalaResult(sala));

            return listaDeSalasResponse;
        }
        
        public IEnumerable<SalaResult> ConsultaDeSalasVip()
        {
            var listaDeSalasResponse = new List<SalaResult>();

            var salas = _salaRepositorio.ObterPorSalaVip();

            foreach (var sala in salas)
                listaDeSalasResponse.Add(new SalaResult(sala));

            return listaDeSalasResponse;
        }

        public IEnumerable<SalaResult> ConsultaDeSalas3D()
        {
            var listaDeSalasResponse = new List<SalaResult>();

            var salas = _salaRepositorio.ObterPorSala3D();

            foreach (var sala in salas)
                listaDeSalasResponse.Add(new SalaResult(sala));

            return listaDeSalasResponse;
        }

        public IEnumerable<SalaResult> ConsultaDeSalasComCapacidadeDisponiveis()
        {
            throw new NotImplementedException();
        }
    }
}
