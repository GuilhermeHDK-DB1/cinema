using Cinema.Dominio.Common;

namespace Cinema.Dominio.Entities.Generos
{
    public class Genero : Entidade
    {
        public string Nome { get; set; }

        public Genero(string nome)
        {
            ValidadorDeRegra.Novo()
                .Quando(string.IsNullOrEmpty(nome), Resources.GeneroInvalido)
                .DispararExcecaoSeExistir();

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
