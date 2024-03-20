using System;
using System.Threading.Tasks;
using colecaohq.Business.Models;

namespace colecaohq.Business.Interface
{
    public interface ITituloHq : IRepository<TituloHQ>
    {
        Task<TituloHQ> ObterTituloHqPorEditora(Guid tituloHqId);
        Task<TituloHQ> ObterTituloHqPorEquipePerssonagem(Guid tituloHqId);
        Task<TituloHQ> ObterTituloHqPorStatus(Guid tituloHqId);
        Task<TituloHQ> ObterTituloHqPorTipoPublicacao(Guid tituloHqId);
    }
}
