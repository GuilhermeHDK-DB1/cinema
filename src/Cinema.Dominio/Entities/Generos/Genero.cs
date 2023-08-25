using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Filmes;

namespace Cinema.Dominio.Entities.Generos
{
    public class Genero : Entidade
    {
        public string Nome { get; set; }
        public IEnumerable<Filme> Filmes {get; set; }

        public Genero(string nome)
        {
            //ValidadorDeRegra.Novo()
            //    .Quando(string.IsNullOrEmpty(nome), Resources.NomeInvalido)
            //    .DispararExcecaoSeExistir();

            Nome = nome;
            Filmes = new List<Filme>();
        }

        public void AlterarNome(string nome)
        {
            //ValidadorDeRegra.Novo()
            //    .Quando(string.IsNullOrEmpty(nome), Resources.NomeInvalido)
            //    .DispararExcecaoSeExistir();

            Nome = nome;
        }

        //Acao,
        //Comedia,
        //Drama,
        //Romance,
        //Documentario,
        //Suspense,
        //Terror,
        //FiccaoCietifica
    }
}
