using Cinema.Dominio.Entities.Ingressos;

namespace Cinema.Dominio.Dtos.Ingressos
{
    public class IngressoResult
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int SessaoId { get; set; }
        public TipoDeIngresso Tipo { get; set; }

        public IngressoResult(Ingresso ingresso)
        {
            Id = ingresso.Id;
            ClienteId = ingresso.Cliente.Id;
            SessaoId = ingresso.Sessao.Id;
            Tipo = ingresso.Tipo;
        }
    }
}
