namespace Cinema.Dominio.Dtos.Ingressos
{
    public class QuantidadeDeIngressosVendidosResult
    {
        public int QuantidadeDeIngressosVendidos { get; set; }

        public QuantidadeDeIngressosVendidosResult(int quantidadeDeIngresso)
        {
            QuantidadeDeIngressosVendidos = quantidadeDeIngresso;
        }
    }
}
