using Microsoft.EntityFrameworkCore;
using MotivoSuporte.Data.Mappings;
using MotivoSuporte.Entities;

namespace MotivoSuporte.Data
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Motivo_Suporte> Motivos_Suporte { get; set; }
        public DbSet<Motivos> Motivos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new MotivoSuporteMap());
            modelBuilder.ApplyConfiguration(new MotivosMap());
        }


    }

}