using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Generos;

namespace Cinema.Dominio.Entities.Filmes
{
    public  class Filme : Entidade
    {
        public string Nome { get; set; }
        public string DataDeLancamento { get; set; }
        public int Duracao { get; set; }
        public Genero Genero { get; set; }

        public Filme(string nome)
        {
            ValidadorDeRegra.Novo()
                .Quando(string.IsNullOrEmpty(nome), Resources.GeneroInvalido)
                .DispararExcecaoSeExistir();

            Nome = nome;
        }
    }
}
