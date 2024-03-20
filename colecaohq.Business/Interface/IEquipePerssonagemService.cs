using System;
using System.Threading.Tasks;
using colecaohq.Business.Models;

namespace colecaohq.Business.Interface
{
    public interface IEquipePerssonagemService : IDisposable
    {
        Task Adicionar(EquipePerssonagem equipePerssonagem);
        Task Atualizar(EquipePerssonagem equipePerssonagem);
        Task Remover(Guid id);
    }
}
