﻿using AVS.Banda.Domain.Entities;
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
        public DbSet<Banda.Domain.Entities.Banda> Bandas { get; set; }
        public DbSet<Album> Albuns { get; set; }
        public DbSet<MusicaPlaylist> MusicaPlaylists { get; set; }

        public SpotifyCloneContext(DbContextOptions<SpotifyCloneContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
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
            return await base.SaveChangesAsync() > 0; ;
        }
    }
}
