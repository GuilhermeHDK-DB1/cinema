using Cinema.Dominio.Entities.Filmes;

namespace Cinema.Dominio.Dtos.Filmes
{
    public class FilmeResult
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DataDeLancamento { get; set; }
        public int Duracao { get; set; }
        public string Classificacao { get; set; }
        //public string Genero { get; set; }

        public FilmeResult(Filme filme)
        {
            Id = filme.Id;
            Nome = filme.Nome;
            DataDeLancamento = filme.DataDeLancamento;
            Duracao = filme.Duracao;
            Classificacao = filme.ClassificacaoString;
            //Genero = filme.Genero.Nome;
        }
    }
}
