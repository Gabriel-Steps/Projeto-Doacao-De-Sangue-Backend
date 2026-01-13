using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoDoacaoDeSangue.Core.Entities;
namespace ProjetoDoacaoDeSangue.Infra.Configurations
{
    public class EstoqueSangueConfiguration : IEntityTypeConfiguration<EstoqueSangue>
    {
        public void Configure(EntityTypeBuilder<EstoqueSangue> builder)
        {
            builder.ToTable("EstoqueSangue");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.TiposSanguineo)
                .IsRequired();

            builder.Property(e => e.FatorRH)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(e => e.QuantidadeMl)
                .IsRequired();

            builder.HasIndex(e => new { e.TiposSanguineo, e.FatorRH })
                .IsUnique();
        }
    }
}
