﻿namespace Cinema.Dominio.Generos
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Genero(string nome)
        {
            if (string.IsNullOrEmpty(nome)) throw new ArgumentException();

            Nome = nome;
        }

        //Acao,
        //Comedia,
        //Drama,
        //Romance,
        //Documentario,
        //Suspense,
        //Terror,
        //FiccaoCietifica
    }
}
