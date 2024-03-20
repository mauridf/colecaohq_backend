using colecaohq.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace colecaohq.Data.Mappings
{
    public class EditoraMapping : IEntityTypeConfiguration<Editora>
    {
        public void Configure(EntityTypeBuilder<Editora> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomeEditora)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1 : 1 => Editora : TituloHQ
            builder.HasMany(f => f.TituloHQs)
                .WithOne(p => p.Editora)
                .HasForeignKey(p => p.EditoraId);

            builder.ToTable("Editora");
        }
    }
}
