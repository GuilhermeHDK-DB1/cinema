using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Generos;
using Cinema.Dominio.Entities.Ingressos;
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
        public IEnumerable<Ingresso> Ingressos { get; set; }

        public Filme()
        {
            Sessoes = new List<FilmeSala>();
            Ingressos = new List<Ingresso>();
        }

        public Filme(string nome, string dataDeLancamento, int duracao, string classificacao, Genero genero)
        {
            Nome = nome;
            DataDeLancamento = dataDeLancamento;
            Duracao = duracao;
            ClassificacaoString = classificacao;
            Genero = genero;

            Sessoes = new List<FilmeSala>();
            Ingressos = new List<Ingresso>();
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarDataDeLancamento(string dataDeLancamento)
        {
            DataDeLancamento = dataDeLancamento;
        }

        public void AlterarDuracao(int duracao)
        {
            Duracao = duracao;
        }

        public void AlterarClassificacao(string classificacao)
        {
            ClassificacaoString = classificacao;
        }

        public void AlterarGenero(Genero genero)
        {
            Genero = genero;
        }
    }
}
