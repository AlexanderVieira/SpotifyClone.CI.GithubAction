using AVS.Cadastro.Domain.Entities;
using AVS.Core.ObjValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AVS.Cadastro.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.OwnsOne(u => u.Email, tf => 
            {
                tf.Property(u => u.Address)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType($"varchar({Email.EMAIL_TAM_MAXIMO})");
            });

            builder.OwnsOne(u => u.Cpf, tf => 
            {
                tf.Property(u => u.Numero)
                .IsRequired()
                .HasColumnName("Cpf")
                .HasColumnType($"varchar({Cpf.CPF_TAM_MAXIMO})");
            });

            builder.HasMany(u => u.Playlists)
                .WithOne()
                .HasForeignKey("UsuarioId");

            builder.ToTable("Usuarios");
        }
    }
}
