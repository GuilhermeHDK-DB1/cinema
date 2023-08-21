using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Generos;
using Cinema.Dominio.Entities.Salas;
using Cinema.Dominio.Entities.Sessao;
using Cinema.Dominio.Extensions;

namespace Cinema.Dominio.Entities.Filmes
{
    public  class Filme : Entidade
    {
        public string Nome { get; set; }
        public string DataDeLancamento { get; set; }
        public int Duracao { get; set; }
        public string ClassificacaoString { get; private set; }
        public ClassificacaoIndicativa Classificacao {
            get { return ClassificacaoString.ParaClassificacao(); }
            set { ClassificacaoString = value.ParaString(); }
        }
        public Genero Genero { get; set; }
        public IEnumerable<FilmeSala> Sessoes { get; set; }

        public Filme(string nome)
        {
            ValidadorDeRegra.Novo()
                .Quando(string.IsNullOrEmpty(nome), Resources.GeneroInvalido)
                .DispararExcecaoSeExistir();

            Nome = nome;
            Sessoes = new List<FilmeSala>();
        }
    }
}
