using Cinema.Dominio.Entities.Generos;

namespace Cinema.Dominio.Dtos.Filmes
{
    public class CadastrarFilmeCommand
    {
        public string Nome { get; set; }
        public string DataDeLancamento { get; set; }
        public int Duracao { get; set; }
        public string Classificacao { get; set; }
        public string Genero { get; set; }
    }
}
