namespace Cinema.Dominio.Dtos.Salas
{
    public class CadastrarSalaCommand
    {
        public string Nome { get; set; }
        public bool SalaVip { get; set; }
        public bool Sala3D { get; set; }
        public int Capacidade { get; set; }
    }
}
