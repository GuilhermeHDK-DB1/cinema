namespace Cinema.Dominio.Dtos.Filmes
{
    public class CadastrarFilmeCommand
    {
        public string Nome { get; set; }
        public string AnoDeLancamento { get; set; }
        public int Duracao { get; set; }
        public string Classificacao { get; set; }
        public string Genero { get; set; }
    }
}
