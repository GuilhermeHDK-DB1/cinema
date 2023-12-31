﻿using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Sessoes;

namespace Cinema.Dominio.Entities.Salas
{
    public class Sala : Entidade
    {
        public string Nome { get; set; }
        public bool SalaVip { get; set; }
        public bool Sala3D { get; set; }
        public int Capacidade { get; set; }
        public IEnumerable<Sessao> Sessoes { get; set; }

        public Sala()
        {
            Sessoes = new List<Sessao>();
        }

        public Sala(string nome, bool salaVip, bool sala3D, int capacidade)
        {
            Nome = nome;
            SalaVip = salaVip;
            Sala3D = sala3D;
            Capacidade = capacidade;

            Sessoes = new List<Sessao>();
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
