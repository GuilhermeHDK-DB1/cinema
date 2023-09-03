namespace Cinema.Dominio.Dtos.Clientes
{
    public class CadastrarClienteCommand
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string DataDeNascimento { get; set; }
    }
}
