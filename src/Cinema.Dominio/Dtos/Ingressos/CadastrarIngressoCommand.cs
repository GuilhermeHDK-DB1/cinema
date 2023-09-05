using Cinema.Dominio.Entities.Ingressos;

namespace Cinema.Dominio.Dtos.Ingressos
{
    public  class CadastrarIngressoCommand
    {
        public int ClienteId { get; set; }
        public int SessaoId { get; set; }
        public TipoDeIngresso Tipo { get; set; }
    }
}
