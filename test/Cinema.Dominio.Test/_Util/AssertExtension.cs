using Cinema.Dominio._Shared.RegrasDeNegocio;
using Xunit;

namespace Cinema.Dominio.Test._Util
{
    public static class AssertExtension
    {
        public static void ComMensagem(this ExcecaoDeDominio exception, string mensagem)
        {
            if (exception.MensagensDeExcecoes.Contains(mensagem))
                Assert.True(true);
            else
                Assert.False(true);
        }
    }
}
