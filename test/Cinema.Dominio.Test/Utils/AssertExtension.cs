using Xunit;
using Cinema.Dominio.Common;

namespace Cinema.Dominio.Test.Utils
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
