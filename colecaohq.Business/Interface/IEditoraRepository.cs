using System;
using System.Threading.Tasks;
using colecaohq.Business.Models;

namespace colecaohq.Business.Interface
{
    public interface IEditoraRepository : IRepository<Editora>
    {
        Task<Editora> ObterEditoraPorTituloHQ(Guid editoraId);
    }
}
