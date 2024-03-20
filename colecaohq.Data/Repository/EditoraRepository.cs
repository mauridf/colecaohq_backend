using System;
using System.Threading.Tasks;
using colecaohq.Business.Interface;
using colecaohq.Business.Models;
using colecaohq.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace colecaohq.Data.Repository
{
    public class EditoraRepository : Repository<Editora>, IEditoraRepository
    {
        public EditoraRepository(MeuDbContext context) : base(context) { }

        public async Task<Editora> ObterEditoraPorTituloHQ(Guid editoraId)
        {
            return await Db.Editoras.AsNoTracking().Include(f => f.TituloHQs)
                .FirstOrDefaultAsync(p => p.Id == editoraId);
        }
    }
}
