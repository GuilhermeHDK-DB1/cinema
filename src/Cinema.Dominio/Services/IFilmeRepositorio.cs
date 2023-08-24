using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Filmes;
using Cinema.Dominio.Entities.Generos;

namespace Cinema.Dominio.Services
{
    public interface IFilmeRepositorio
    {
        Filme ObterPeloNome(string nome);
        void Adicionar(Filme entity);
        void Atualizar(Filme entity);
        void Excluir(Filme entity);
        Filme ObterPorId(int id);
        List<Filme> ObterTodos();
    }
}
