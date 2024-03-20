using System;
using System.Threading.Tasks;
using colecaohq.Business.Interface;
using colecaohq.Business.Models;
using colecaohq.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace colecaohq.Data.Repository
{
    public class HqPerssonagemRepository : Repository<HqPerssonagem>, IHqPerssonagem
    {
        public HqPerssonagemRepository(MeuDbContext context) : base(context) { }
    }
}
