using Cinema.Dominio.Entities.Ingressos;
using Cinema.Dominio.Entities.Sessoes;

namespace Cinema.Dominio.Entities
{
    public class SessaoIngresso
    {
        public Sessao Sessao { get; set; }
        public Ingresso Ingresso { get; set; }
    }
}
