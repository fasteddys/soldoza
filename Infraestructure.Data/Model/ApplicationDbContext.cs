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
        public DbSet<SOLDOZA_MST_ZONAS> zonas { get; set; }
        public DbSet<SOLDOZA_ADM_MST_LADOS> lados { get; set; }
        public DbSet<SOLDOZA_MST_RESULT_END> rend { get; set; }
        public DbSet<SOLDOZA_MST_POS_SOLDEO> posol { get; set; }
        public DbSet<SOLDOZA_MST_LUGAR_SOLDEO> lusol { get; set; }
        public DbSet<SOLDOZA_MST_END> enode { get; set; }
        public DbSet<SOLDOZA_MST_DIS_SOLDADURA> disol { get; set; }
        public DbSet<SOLDOZA_MST_PROC_SOLDADURA> prosol { get; set; }
        public DbSet<SOLDOZA_MST_TIPO_JUNTA> tijun { get; set; }
        public DbSet<SOLDOZA_MST_PLANOS> planos { get; set; }
        public DbSet<SOLDOZA_MST_SUBZONAS> suzona { get; set; }
        public DbSet<SOLDOZA_ADM_MST_CONSU_MARCA> comar { get; set; }
        public DbSet<SOLDOZA_ADM_MST_CONSU_FABRICANTE> cofab { get; set; }
        public DbSet<SOLDOZA_ADM_MST_CONSU_CLASF_AWS> coclasfaws { get; set; }
        public DbSet<SOLDOZA_MST_CONSUMIBLES> consu { get; set; }


        public DbSet<SOLDOZA_MST_MATERIALES> materiales { get; set; }
        public DbSet<SOLDOZA_PY_REVISIONES> revisiones { get; set; }
        public DbSet<SOLDOZA_PY_REVISIONES_FECHAS> revisiones_fechas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<vpagoSuscripcion>().HasNoKey();

            modelBuilder.Entity<SOLDOZA_MST_MATERIALES>().HasKey(t => new { t.id });

            modelBuilder.Entity<SOLDOZA_MST_TIPO_DOCUMENTO>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_PAIS>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_GRL_CLIENTES>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_GRL_PROYECTOS>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_GRL_PROYECTOVERSION>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_TIPO_CONTACTO>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_GRL_CONTACTOS>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_CONTACTOS_PROYECTO>().HasKey(cp => new { cp.contacto_id, cp.proyecto_id });
            modelBuilder.Entity<SOLDOZA_MST_ZONAS>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_ADM_MST_LADOS>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_RESULT_END>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_POS_SOLDEO>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_LUGAR_SOLDEO>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_END>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_DIS_SOLDADURA>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_PROC_SOLDADURA>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_TIPO_JUNTA>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_PLANOS>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_SUBZONAS>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_ADM_MST_CONSU_MARCA>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_ADM_MST_CONSU_FABRICANTE>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_ADM_MST_CONSU_CLASF_AWS>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_MST_CONSUMIBLES>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_PY_REVISIONES>().HasKey(t => new { t.id });
            modelBuilder.Entity<SOLDOZA_PY_REVISIONES_FECHAS>().HasKey(t => new { t.id });


            modelBuilder.Entity<SOLDOZA_MST_TIPO_DOCUMENTO>().HasMany(u => u.clientes).WithOne(u => u.tipodocumento).HasForeignKey(u => u.tipo_documento_id);
            modelBuilder.Entity<SOLDOZA_MST_GRL_CLIENTES>().HasMany(u => u.proyectos).WithOne(u => u.clientes).HasForeignKey(u => u.cliente_id);
            modelBuilder.Entity<SOLDOZA_MST_GRL_PROYECTOS>().HasMany(u => u.versiones).WithOne(u => u.proyecto).HasForeignKey(u => u.proyecto_id);

            modelBuilder.Entity<SOLDOZA_MST_GRL_CONTACTOS>().HasMany(u => u.contactos).WithOne(u => u.contacto).HasForeignKey(u => u.contacto_id);
            modelBuilder.Entity<SOLDOZA_MST_GRL_PROYECTOS>().HasMany(u => u.contactos).WithOne(u => u.proyecto).HasForeignKey(u => u.proyecto_id);
            modelBuilder.Entity<SOLDOZA_MST_TIPO_CONTACTO>().HasMany(u => u.contactos).WithOne(u => u.tipocontacto).HasForeignKey(u => u.tipo_contacto_id);
            modelBuilder.Entity<SOLDOZA_MST_GRL_PROYECTOS>().HasMany(u => u.planos).WithOne(u => u.proyecto).HasForeignKey(u => u.proyecto_id);

            modelBuilder.Entity<SOLDOZA_MST_PLANOS>().HasMany(u => u.revisiones).WithOne(u => u.plano).HasForeignKey(u => u.plano_id);
            modelBuilder.Entity<SOLDOZA_PY_REVISIONES>().HasMany(u => u.fechas).WithOne(u => u.revision).HasForeignKey(u => u.revision_id);

            modelBuilder.Entity<SOLDOZA_MST_ZONAS>().HasMany(u => u.subzona).WithOne(u => u.zona).HasForeignKey(u => u.zona_id);
            modelBuilder.Entity<SOLDOZA_ADM_MST_CONSU_MARCA>().HasMany(u => u.consu).WithOne(u => u.marca).HasForeignKey(u => u.marca_id);
            modelBuilder.Entity<SOLDOZA_ADM_MST_CONSU_FABRICANTE>().HasMany(u => u.consu).WithOne(u => u.fabricante).HasForeignKey(u => u.fabricante_id);
            modelBuilder.Entity<SOLDOZA_ADM_MST_CONSU_CLASF_AWS>().HasMany(u => u.consu).WithOne(u => u.clasf_aws).HasForeignKey(u => u.clasf_aws_id);
            modelBuilder.Entity<SOLDOZA_MST_PROC_SOLDADURA>().HasMany(u => u.consu).WithOne(u => u.proc_soldadura).HasForeignKey(u => u.proc_soldadura_id);


            //modelBuilder.Entity<Categoria>().HasMany(c => c.catalogos).WithOne(c => c.categoria).HasForeignKey(c => c.categoriaID).IsRequired();

            // Campos NULOS
            modelBuilder.Entity<SOLDOZA_MST_GRL_PROYECTOS>().Property(p => p.fecha_actualizacion).IsRequired(false);
            modelBuilder.Entity<SOLDOZA_MST_GRL_PROYECTOS>().Property(p => p.usuario_actualizacion).IsRequired(false);


        }

    }




}
