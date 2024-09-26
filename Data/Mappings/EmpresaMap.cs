using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotivoSuporte.Entities;

namespace MotivoSuporte.Data.Mappings
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");

            builder.HasKey(x => x.Idf_Empresa);

            builder.Property(x => x.Idf_Empresa)
                .HasColumnName("Idf_Empresa");

            builder.Property(x => x.Num_CNPJ)
                .HasColumnName("Num_CNPJ");

            builder.Property(x => x.Raz_Social)
                .HasColumnName("Raz_Social");
        }
    }

}
