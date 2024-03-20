using System;
using System.Threading.Tasks;
using colecaohq.Business.Models;

namespace colecaohq.Business.Interface
{
    public interface IEditoraService : IDisposable
    {
        Task Adicionar(Editora editora);
        Task Atualizar(Editora editora);
        Task Remover(Guid id);
    }
}
