using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoDoacaoDeSangue.Core.Entities;

namespace ProjetoDoacaoDeSangue.Infra.Configurations
{
    public class DoacaoConfiguration : IEntityTypeConfiguration<Doacao>
    {
        public void Configure(EntityTypeBuilder<Doacao> builder)
        {
            builder.ToTable("Doacoes");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.DataDoacao)
                .IsRequired();

            builder.Property(d => d.QuantidadeMl)
                .IsRequired();

            builder.HasOne(d => d.Doador)
                .WithMany()
                .HasForeignKey(d => d.DoadorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
