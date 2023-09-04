namespace Cinema.Dominio.Dtos.Ingressos
{
    public class QuantidadeDeIngressoResult
    {
        public int QuantidadeDeIngressosVendidos { get; set; }

        public QuantidadeDeIngressoResult(int quantidadeDeIngresso)
        {
            QuantidadeDeIngressosVendidos = quantidadeDeIngresso;
        }
    }
}
