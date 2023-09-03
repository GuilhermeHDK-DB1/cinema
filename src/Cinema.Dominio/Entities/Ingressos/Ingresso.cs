using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Clientes;
using Cinema.Dominio.Entities.Sessoes;

namespace Cinema.Dominio.Entities.Ingressos
{
    public class Ingresso : Entidade
    {
        public Cliente Cliente { get; set; }
        public Sessao Sessao { get; set; }
        public TipoDeIngresso Tipo { get; set; }

        public Ingresso()
        {
        }
    }
}
