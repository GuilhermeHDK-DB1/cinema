namespace Cinema.Dominio.Dtos.Salas
{
    public class AtualizarSalaCommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool SalaVip { get; set; }
        public bool Sala3D { get; set; }
        public int Capacidade { get; set; }
    }
}
