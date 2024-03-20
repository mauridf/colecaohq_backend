using System;
using System.Threading.Tasks;
using colecaohq.Business.Interface;
using colecaohq.Business.Models;
using colecaohq.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace colecaohq.Data.Repository
{
    public class TituloHqRepository : Repository<TituloHQ>, ITituloHq
    {
        public TituloHqRepository(MeuDbContext context) : base(context) { }

        public async Task<TituloHQ> ObterTituloHqPorEditora(Guid tituloHqId)
        {
            return await Db.TituloHQs.AsNoTracking().Include(f => f.Editora)
                .FirstOrDefaultAsync(p => p.Id == tituloHqId);
        }
        public async Task<TituloHQ> ObterTituloHqPorEquipePerssonagem(Guid tituloHqId)
        {
            return await Db.TituloHQs.AsNoTracking().Include(f => f.HqPerssonagems)
                .FirstOrDefaultAsync(p => p.Id == tituloHqId);
        }
        public async Task<TituloHQ> ObterTituloHqPorStatus(Guid tituloHqId)
        {
            return await Db.TituloHQs.AsNoTracking().Include(f => f.Status)
                .FirstOrDefaultAsync(p => p.Id == tituloHqId);
        }
        public async Task<TituloHQ> ObterTituloHqPorTipoPublicacao(Guid tituloHqId)
        {
            return await Db.TituloHQs.AsNoTracking().Include(f => f.TipoPublicacao)
                .FirstOrDefaultAsync(p => p.Id == tituloHqId);
        }
    }
}
