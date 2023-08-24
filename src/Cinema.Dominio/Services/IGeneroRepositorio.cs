using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Generos;

namespace Cinema.Dominio.Services
{
    public interface IGeneroRepositorio
    {
        Genero ObterPeloNome(string nome);
        void Adicionar(Genero entity);
        void Atualizar(Genero entity);
        void Excluir(Genero entity);
        Genero ObterPorId(int id);
        List<Genero> ObterTodos();
    }
}
