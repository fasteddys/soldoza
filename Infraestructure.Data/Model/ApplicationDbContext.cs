using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Model
{
    public class ApplicationDbContext : DbContext  //IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
               => optionsBuilder.UseNpgsql("Server=dbsoldoza.postgres.database.azure.com;Database=postgres;Port=5432;User Id=adminsoldoza@dbsoldoza;Password=...Soldoza2021;Ssl Mode=Require;");
        public DbSet<SOLDOZA_MST_TIPO_DOCUMENTO> tipodocumento { get; set; }
        public DbSet<SOLDOZA_MST_PAIS> paises { get; set; }
        public DbSet<SOLDOZA_MST_GRL_CLIENTES> clientes { get; set; }
        public DbSet<SOLDOZA_MST_GRL_PROYECTOS> proyectos { get; set; }
        public DbSet<SOLDOZA_MST_GRL_PROYECTOVERSION> versiones { get; set; }
        public DbSet<SOLDOZA_MST_TIPO_CONTACTO> tipocontacto { get; set; }
        public DbSet<SOLDOZA_MST_GRL_CONTACTOS> contactos { get; set; }
        public DbSet<SOLDOZA_MST_CONTACTOS_PROYECTO> contactosproyecto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<vpagoSuscripcion>().HasNoKey();
     

            modelBuilder.Entity<SOLDOZA_MST_TIPO_DOCUMENTO>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_PAIS>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_GRL_CLIENTES>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_GRL_PROYECTOS>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_GRL_PROYECTOVERSION>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_TIPO_CONTACTO>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_GRL_CONTACTOS>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_CONTACTOS_PROYECTO>().HasKey(cp => new { cp.contacto_id, cp.proyecto_id });


            modelBuilder.Entity<SOLDOZA_MST_TIPO_DOCUMENTO>().HasMany(u => u.clientes).WithOne(u => u.tipodocumento).HasForeignKey(u => u.tipo_documento_id);
            modelBuilder.Entity<SOLDOZA_MST_GRL_CLIENTES>().HasMany(u => u.proyectos).WithOne(u => u.clientes).HasForeignKey(u => u.cliente_id);
            modelBuilder.Entity<SOLDOZA_MST_GRL_PROYECTOS>().HasMany(u => u.versiones).WithOne(u => u.proyecto).HasForeignKey(u => u.proyecto_id);

            modelBuilder.Entity<SOLDOZA_MST_GRL_CONTACTOS>().HasMany(u => u.contactos).WithOne(u => u.contacto).HasForeignKey(u => u.contacto_id);
            modelBuilder.Entity<SOLDOZA_MST_GRL_PROYECTOS>().HasMany(u => u.contactos).WithOne(u => u.proyecto).HasForeignKey(u => u.proyecto_id);
            modelBuilder.Entity<SOLDOZA_MST_TIPO_CONTACTO>().HasMany(u => u.contactos).WithOne(u => u.tipocontacto).HasForeignKey(u => u.tipo_contacto_id);
          

            //modelBuilder.Entity<Categoria>().HasMany(c => c.catalogos).WithOne(c => c.categoria).HasForeignKey(c => c.categoriaID).IsRequired();

            // Campos NULOS
            modelBuilder.Entity<SOLDOZA_MST_GRL_PROYECTOS>().Property(p => p.fecha_actualizacion).IsRequired(false);
            modelBuilder.Entity<SOLDOZA_MST_GRL_PROYECTOS>().Property(p => p.usuario_actualizacion).IsRequired(false);


        }

    }




}
