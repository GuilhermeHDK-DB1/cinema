using Cinema.Dominio._Shared.RegrasDeNegocio;

namespace Cinema.Dominio.Generos
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Genero(string nome)
        {
            ValidadorDeRegra.Novo()
                .Quando(string.IsNullOrEmpty(nome), Mensagens.GeneroInvalido)
                .DisparaExcecaoSeExistir();

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
