using colecaohq.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace colecaohq.Data.Mappings
{
    public class EquipePerssonagemMapping : IEntityTypeConfiguration<EquipePerssonagem>
    {
        public void Configure(EntityTypeBuilder<EquipePerssonagem> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomeEquipePerssonagem)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.DescricaoEquipePerssonagem)
                .HasColumnType("varchar(MAX)");

            // 1 : 1 => Editora : TituloHQ
            builder.HasMany(f => f.HqPerssonagens)
                .WithOne(p => p.EquipePerssonagem)
                .HasForeignKey(p => p.EquipePerssonagemId);

            builder.ToTable("EquipePerssonagem");
        }
    }
}
