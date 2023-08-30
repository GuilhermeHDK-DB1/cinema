using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Sessao;

namespace Cinema.Dominio.Services
{
    public interface ISessaoRepositorio
    {
        void Adicionar(FilmeSala entity);
        void Atualizar(FilmeSala entity);
        void Excluir(FilmeSala entity);
        FilmeSala ObterPorChave(int filmeId, int salaId, DateTime horario);
        List<FilmeSala> ObterTodos();
        List<FilmeSala> ObterPaginado(int skip, int take);

    }
}
