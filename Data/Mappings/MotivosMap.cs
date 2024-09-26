using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotivoSuporte.Entities;
namespace MotivoSuporte.Data.Mappings
{
    public class MotivosMap : IEntityTypeConfiguration<Motivos>
    {
        public void Configure(EntityTypeBuilder<Motivos> builder)
        {
            builder.ToTable("Motivos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Motivo)
                .HasColumnName("Motivos")
                .IsRequired();
        }
    }
}
