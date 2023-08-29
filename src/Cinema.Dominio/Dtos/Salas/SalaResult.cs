using Cinema.Dominio.Entities.Salas;

namespace Cinema.Dominio.Dtos.Salas
{
    public class SalaResult
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool SalaVip { get; set; }
        public bool Sala3D { get; set; }
        public int Capacidade { get; set; }

        public SalaResult(Sala sala)
        {
            Id = sala.Id;
            Nome = sala.Nome;
            SalaVip = sala.SalaVip;
            Sala3D = sala.Sala3D;
            Capacidade = sala.Capacidade;
        }
    }
}
