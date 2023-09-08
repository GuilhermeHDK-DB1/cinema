namespace Cinema.Dominio.Dtos.Ingressos
{
    public class QuantidadeDeIngressoDisponiveisResult
    {
        public int QuantidadeDeIngressosDisponiveis { get; set; }

        public QuantidadeDeIngressoDisponiveisResult(int quantidadeDeIngresso)
        {
            QuantidadeDeIngressosDisponiveis = quantidadeDeIngresso;
        }
    }
}
