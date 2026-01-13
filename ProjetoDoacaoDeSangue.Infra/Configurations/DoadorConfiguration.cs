using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoDoacaoDeSangue.Core.Entities;

namespace ProjetoDoacaoDeSangue.Infra.Configurations
{
    public class DoadorConfiguration : IEntityTypeConfiguration<Doador>
    {
        public void Configure(EntityTypeBuilder<Doador> builder)
        {
            builder.ToTable("Doadores");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.NomeCompleto)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(d => d.Email)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(d => d.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(d => d.Email)
                .IsUnique();

            builder.Property(d => d.DataNascimento)
                .IsRequired();

            builder.Property(d => d.Genero)
                .IsRequired();

            builder.Property(d => d.Peso)
                .IsRequired();

            builder.Property(d => d.TipoSanguineo)
                .IsRequired();

            builder.Property(d => d.FatorRh)
                .IsRequired()
                .HasMaxLength(3);
        }
    }
}
