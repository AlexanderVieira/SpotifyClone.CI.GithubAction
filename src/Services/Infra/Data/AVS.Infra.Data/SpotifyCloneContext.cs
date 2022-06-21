using AVS.Banda.Domain;
using AVS.Cadastro.Domain.Entities;
using AVS.Core.Data;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace AVS.Infra.Data
{
    public class SpotifyCloneContext : DbContext, IUnitOfWork
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Banda.Domain.Banda> Bandas { get; set; }
        public DbSet<Album> Albuns { get; set; }

        public SpotifyCloneContext(DbContextOptions<SpotifyCloneContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }
            
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpotifyCloneContext).Assembly);

            foreach(var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientCascade;
            }

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            //foreach (var entry in ChangeTracker.Entries()
            //    .Where(e => e.Entity.GetType().GetProperty("DataCadastro") != null))
            //{
            //    if (entry.State == EntityState.Added)
            //    {
            //        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
            //    }

            //    if (entry.State == EntityState.Modified)
            //    {
            //        entry.Property("DataCadastro").IsModified = false;
            //    }
            //}
            var sucesso = await base.SaveChangesAsync() > 0;            
            return sucesso;
        }
    }
}
