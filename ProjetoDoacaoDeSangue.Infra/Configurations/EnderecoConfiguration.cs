using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoDoacaoDeSangue.Core.Entities;

namespace ProjetoDoacaoDeSangue.Infra.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Cidade)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.UF)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasOne(e => e.Doador)
                .WithOne()
                .HasForeignKey<Endereco>(e => e.DoadorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
