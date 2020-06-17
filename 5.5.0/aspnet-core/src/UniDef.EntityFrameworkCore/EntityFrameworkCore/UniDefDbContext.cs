using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using UniDef.Authorization.Roles;
using UniDef.Authorization.Users;
using UniDef.MultiTenancy;
using UniDef.Eventos;
using UniDef.Seguidores;
using UniDef.Asistentes;

namespace UniDef.EntityFrameworkCore
{
    public class UniDefDbContext : AbpZeroDbContext<Tenant, Role, User, UniDefDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public UniDefDbContext(DbContextOptions<UniDefDbContext> options)
            : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Seguidor> Seguidores { get; set; }
        public DbSet<Asistente> Asistentes { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Un seguidor tiene un usuario seguido
            //con muchos usuarios seguidos
            //n:m?
            modelBuilder.Entity<Seguidor>()
                .HasOne(sg => sg.UsuarioSeguido)
                .WithMany(p => p.UsuariosSeguidos)
                .HasForeignKey(pt => pt.UsuarioSeguidoId)
                .OnDelete(DeleteBehavior.Restrict);

            //Un seguidor tiene un usuario seguidor
            //con muchos usuarios seguidores
            //n:m??
            modelBuilder.Entity<Seguidor>()
                .HasOne(sg => sg.UsuarioSeguidor)
                .WithMany(t => t.UsuariosSeguidores)
                .HasForeignKey(pt => pt.UsuarioSeguidorId)
                .OnDelete(DeleteBehavior.Restrict);

            /*
            modelBuilder.Entity<Asistente>()
                .HasOne(ev => ev.UsuarioAsistente)
                .WithMany(e => e.EventosCreados)
                .HasForeignKey(asi => asi.UsuarioAsistenteId)
                .OnDelete(DeleteBehavior.Restrict);
                */
            
        }
    }
}
