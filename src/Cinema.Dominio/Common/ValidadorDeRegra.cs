namespace Cinema.Dominio.Common
{
    public class ValidadorDeRegra
    {
        private readonly List<string> _mensagensDeExcecoes;

        private ValidadorDeRegra()
        {
            _mensagensDeExcecoes = new List<string>();
        }

        public static ValidadorDeRegra Novo()
        {
            return new ValidadorDeRegra();
        }

        public ValidadorDeRegra Quando(bool condicao, string mensagemDeErro)
        {
            if (condicao) _mensagensDeExcecoes.Add(mensagemDeErro);

            return this;
        }

        public void DisparaExcecaoSeExistir()
        {
            if (_mensagensDeExcecoes.Any())
                throw new ExcecaoDeDominio(_mensagensDeExcecoes);
        }
    }

    public class ExcecaoDeDominio : ArgumentException
    {
        public List<string> MensagensDeExcecoes { get; set; }

        public ExcecaoDeDominio(List<string> mensagensDeExcecoes)
        {
            MensagensDeExcecoes = mensagensDeExcecoes;
        }
    }
}
