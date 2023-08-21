using System.Collections.Generic;

namespace Cinema.Dominio.Common
{
    public interface IRepositorio<TEntidade>
    {
        TEntidade ObterPorId(int id);
        List<TEntidade> Consultar();
        void Adicionar(TEntidade entity);
    }
}
