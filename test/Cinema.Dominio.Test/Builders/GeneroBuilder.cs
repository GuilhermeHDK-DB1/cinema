using Cinema.Dominio.Entities.Generos;

namespace Cinema.Dominio.Test.Builders
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
            {
                var propertyInfo = genero.GetType().GetProperty("Id");
                propertyInfo.SetValue(genero, Convert.ChangeType(_id, propertyInfo.PropertyType), null);
            }

            return genero;
        }
    }
}
