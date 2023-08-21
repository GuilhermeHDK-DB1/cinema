using Cinema.Dominio.Entities.Filmes;

namespace Cinema.Dominio.Extensions
{
    public static class ClassificacaoIndicativaExtension
    {
        public static string ParaString(this ClassificacaoIndicativa classificacao)
        {
            var dicionario = new Dictionary<ClassificacaoIndicativa, string>
            {
                { ClassificacaoIndicativa.Livre, "G" },
                { ClassificacaoIndicativa.MaiorQue10, "PG" },
                { ClassificacaoIndicativa.MaiorQue13, "PG-13" },
                { ClassificacaoIndicativa.MaiorQue14, "R" },
                { ClassificacaoIndicativa.MaiorQue18, "NC-17" },
            };

            return dicionario.First(d => d.Key == classificacao).Value;
        }

        public static ClassificacaoIndicativa ParaClassificacao(this string classificacao)
        {
            var dicionario = new Dictionary<ClassificacaoIndicativa, string>
            {
                { ClassificacaoIndicativa.Livre, "G" },
                { ClassificacaoIndicativa.MaiorQue10, "PG" },
                { ClassificacaoIndicativa.MaiorQue13, "PG-13" },
                { ClassificacaoIndicativa.MaiorQue14, "R" },
                { ClassificacaoIndicativa.MaiorQue18, "NC-17" },
            };

            return dicionario.First(d => d.Value == classificacao).Key;
        }
    }
}
