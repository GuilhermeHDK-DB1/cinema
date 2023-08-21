using Cinema.Dominio.Common;

namespace Cinema.Dominio.Entities.Salas
{
    public class Sala : Entidade
    {
        public string Nome { get; set; }
        public bool SalaVip { get; set; }
        public bool Sala3D { get; set; }
        public int Capacidade { get; set; }

        public Sala(string nome)
        {
            ValidadorDeRegra.Novo()
                .Quando(string.IsNullOrEmpty(nome), Resources.GeneroInvalido)
                .DispararExcecaoSeExistir();

            Nome = nome;
        }
    }
}
