using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotivoSuporte.Entities;

namespace MotivoSuporte.Data.Mappings
{
    public class MotivoSuporteMap : IEntityTypeConfiguration<Motivo_Suporte>
    {
      public void Configure(EntityTypeBuilder<Motivo_Suporte> builder) 
      {
            builder.ToTable("Motivo_Suporte");
            builder.HasKey(x => x.Id);
            
            builder.Property(ms => ms.Id)
                .HasColumnName("Id");

            builder.Property(ms => ms.Idf_Empresa)
                .HasColumnName("Idf_Empresa");

            builder.Property(ms => ms.Motivo)
                .HasColumnName("Motivo");

            builder.Property(ms => ms.Des_Motivo)
                .HasColumnName("Des_Motivo");

            builder.Property(ms => ms.Num_CNPJ)
                .HasColumnName("Num_CNPJ");

            builder.Property(ms => ms.Raz_Social)
                .HasColumnName("Raz_Social");

            builder.Property(ms => ms.Email)
                .HasColumnName("Email");

            builder.Property(ms => ms.Telefone)
                .HasColumnName("telefone");

            builder.Property(ms => ms.Situacao)
                .HasColumnName("Situacao");

            builder.Property(ms => ms.Qtde_Admissoes)
                .HasColumnName("Qtde_Admissoes");

            builder.Property(ms => ms.Qtde_Funcionarios)
                .HasColumnName("Qtde_Funcionarios");

            builder.Property(ms => ms.Origem)
                .HasColumnName("Origem");
      }
    }
}
