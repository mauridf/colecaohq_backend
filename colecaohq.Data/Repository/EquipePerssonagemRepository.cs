using System;
using System.Threading.Tasks;
using colecaohq.Business.Interface;
using colecaohq.Business.Models;
using colecaohq.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace colecaohq.Data.Repository
{
    public class EquipePerssonagemRepository : Repository<EquipePerssonagem>, IEquipePerssonagem
    {
        public EquipePerssonagemRepository(MeuDbContext context) : base(context) { }

        public async Task<EquipePerssonagem> ObterEquipePerssonagemPorTituloHQ(Guid equipePersonagemId)
        {
            return await Db.EquipePerssonagems.AsNoTracking().Include(f => f.HqPerssonagens)
                .FirstOrDefaultAsync(p => p.Id == equipePersonagemId);
        }
    }
}
