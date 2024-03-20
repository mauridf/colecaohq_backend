using colecaohq.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace colecaohq.Data.Mappings
{
    class HqPerssonagemMapping : IEntityTypeConfiguration<HqPerssonagem>
    {
        public void Configure(EntityTypeBuilder<HqPerssonagem> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("HqPerssonagem");
        }
    }
}
