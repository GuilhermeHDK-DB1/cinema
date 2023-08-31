using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Clientes;

namespace Cinema.Dominio.Entities.Ingressos
{
    public class Ingresso : Entidade
    {
        public Cliente Cliente { get; set; }
        public TipoDeIngresso Tipo { get; set; }
    }
}
