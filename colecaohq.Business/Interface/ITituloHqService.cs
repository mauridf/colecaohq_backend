using System;
using System.Threading.Tasks;
using colecaohq.Business.Models;

namespace colecaohq.Business.Interface
{
    public interface ITituloHqService : IDisposable
    {
        Task Adicionar(TituloHQ tituloHQ);
        Task Atualizar(TituloHQ tituloHQ);
        Task Remover(Guid id);
    }
}
