using Cinema.Dominio.Entities.Filmes;

namespace Cinema.Dominio.Extensions
{
    public static class ClassificacaoIndicativaExtension
    {
        private static Dictionary<ClassificacaoIndicativa, string> _dicionario = 
            new Dictionary<ClassificacaoIndicativa, string>
            {
                { ClassificacaoIndicativa.Livre, "G" },
                { ClassificacaoIndicativa.MaiorQue10, "PG" },
                { ClassificacaoIndicativa.MaiorQue13, "PG-13" },
                { ClassificacaoIndicativa.MaiorQue14, "R" },
                { ClassificacaoIndicativa.MaiorQue18, "NC-17" },
            };
        public static Dictionary<ClassificacaoIndicativa, string> Dicionario { get { return _dicionario; } }

        public static string ParaString(this ClassificacaoIndicativa classificacao)
        {
            return Dicionario.First(d => d.Key == classificacao).Value;
        }

        public static ClassificacaoIndicativa ParaClassificacao(this string classificacao)
        {
            return Dicionario.First(d => d.Value == classificacao).Key;
        }
    }
}
