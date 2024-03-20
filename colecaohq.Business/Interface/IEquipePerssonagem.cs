using System;
using System.Threading.Tasks;
using colecaohq.Business.Models;

namespace colecaohq.Business.Interface
{
    public interface IEquipePerssonagem : IRepository<EquipePerssonagem>
    {
        Task<EquipePerssonagem> ObterEquipePerssonagemPorTituloHQ(Guid equipePersonagemId);
    }
}
