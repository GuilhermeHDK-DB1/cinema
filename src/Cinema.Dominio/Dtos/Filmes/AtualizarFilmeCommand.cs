namespace Cinema.Dominio.Dtos.Filmes
{
    public class AtualizarFilmeCommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DataDeLancamento { get; set; }
        public int Duracao { get; set; }
        public string Classificacao { get; set; }
        public string Genero { get; set; }
    }
}
