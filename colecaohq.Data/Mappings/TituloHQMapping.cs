using colecaohq.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace colecaohq.Data.Mappings
{
    public class TituloHQMapping : IEntityTypeConfiguration<TituloHQ>
    {
        public void Configure(EntityTypeBuilder<TituloHQ> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.TituloOriginal)
                .HasColumnType("varchar(200)");

            builder.Property(p => p.TotalEdicoes)
                .HasColumnType("varchar(200)");

            builder.Property(p => p.EdicoesPossuidas)
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Sinopse)
                .HasColumnType("varchar(MAX)");

            builder.Property(p => p.AnoLancamento)
                .HasColumnType("varchar(4)");

            // 1 : 1 => Editora : TituloHQ
            builder.HasMany(f => f.HqPerssonagems)
                .WithOne(p => p.TituloHQ)
                .HasForeignKey(p => p.TituloHqId);

            builder.ToTable("TituloHQ");
        }
    }
}
