using Cinema.Dominio.Generos;

namespace Cinema.Dominio.Test._Builders
{
    public class GeneroBuilder
    {
        private int _id;
        private string _nome = "acao";

        public static GeneroBuilder Novo()
        {
            return new GeneroBuilder();
        }

        public GeneroBuilder ComId(int id)
        {
            _id = id;
            return this;
        }

        public GeneroBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public Genero Build()
        {
            var genero = new Genero(_nome);

            if (_id > 0)
                genero.Id = _id;

            return genero;
        }
    }
}
