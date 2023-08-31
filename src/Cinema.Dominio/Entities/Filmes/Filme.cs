using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Generos;
using Cinema.Dominio.Entities.Sessoes;
using Cinema.Dominio.Extensions;

namespace Cinema.Dominio.Entities.Filmes
{
    public  class Filme : Entidade
    {
        public string Nome { get; set; }
        public string AnoDeLancamento { get; set; }
        public int Duracao { get; set; }
        public string ClassificacaoString { get; private set; }
        public ClassificacaoIndicativa Classificacao {
            get { return ClassificacaoString.ParaClassificacao(); }
            set { ClassificacaoString = value.ParaString(); }
        }
        public Genero Genero { get; set; }
        public IEnumerable<Sessao> Sessoes { get; set; }

        public Filme()
        {
            Sessoes = new List<Sessao>();
        }

        public Filme(string nome, string anoDeLancamento, int duracao, string classificacao, Genero genero)
        {
            Nome = nome;
            AnoDeLancamento = anoDeLancamento;
            Duracao = duracao;
            Classificacao = classificacao.ParaClassificacao();
            Genero = genero;

            Sessoes = new List<Sessao>();
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarAnoDeLancamento(string anoDeLancamento)
        {
            AnoDeLancamento = anoDeLancamento;
        }

        public void AlterarDuracao(int duracao)
        {
            Duracao = duracao;
        }

        public void AlterarClassificacao(string classificacao)
        {
            Classificacao = classificacao.ParaClassificacao();
        }

        public void AlterarGenero(Genero genero)
        {
            Genero = genero;
        }
    }
}
