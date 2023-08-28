namespace Cinema.Dominio.Extensions
{
    public static class ValidatorExtension
    {
        public static bool ValidarClassificacaoIndicativa(string classificacao)
        {
            if (string.IsNullOrEmpty(classificacao))
                return false;

            return ClassificacaoIndicativaExtension.Dicionario.ContainsValue(classificacao);
        }
    }
}
