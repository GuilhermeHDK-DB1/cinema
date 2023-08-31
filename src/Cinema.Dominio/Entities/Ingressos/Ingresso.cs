using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Clientes;
using Cinema.Dominio.Entities.Filmes;
using Cinema.Dominio.Entities.Salas;

namespace Cinema.Dominio.Entities.Ingressos
{
    public class Ingresso : Entidade
    {
        public Cliente Cliente { get; set; }
        public Sala Sala { get; set; }
        public TipoDeIngresso Tipo { get; set; }
    }
}
