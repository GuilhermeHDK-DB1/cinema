using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Ingressos;
using Cinema.Dominio.Entities.Sessao;

namespace Cinema.Dominio.Entities.Salas
{
    public class Sala : Entidade
    {
        public string Nome { get; set; }
        public bool SalaVip { get; set; }
        public bool Sala3D { get; set; }
        public int Capacidade { get; set; }
        public IEnumerable<FilmeSala> Sessoes { get; set; }
        public IEnumerable<Ingresso> Ingressos { get; set; }

        public Sala()
        {
            Sessoes = new List<FilmeSala>();
            Ingressos = new List<Ingresso>();
        }

        public Sala(string nome, bool salaVip, bool sala3D, int capacidade)
        {
            Nome = nome;
            SalaVip = salaVip;
            Sala3D = sala3D;
            Capacidade = capacidade;

            Sessoes = new List<FilmeSala>();
            Ingressos = new List<Ingresso>();
        }

        public void AtualizarNome(string nome)
            => Nome = nome;

        public void AtualizarSalaVip(bool salaVip)
            => SalaVip = salaVip;

        public void AtualizarSala3D(bool sala3D)
            => Sala3D = sala3D;

        public void AtualizarCapacidade(int capacidade)
            => Capacidade = capacidade;
    }
}
