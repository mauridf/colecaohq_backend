using System;
using System.Threading.Tasks;
using colecaohq.Business.Models;

namespace colecaohq.Business.Interface
{
    public interface IHqPerssonagemService : IDisposable
    {
        Task Adicionar(HqPerssonagem hqPerssonagem);
        Task Atualizar(HqPerssonagem hqPerssonagem);
        Task Remover(Guid id);
    }
}
