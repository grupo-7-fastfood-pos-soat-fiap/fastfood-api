using FastFoodFIAP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FastFoodFIAP.Infra.Data.Mappings
{
    public class LgpdClientesMap : IEntityTypeConfiguration<LgpdCliente>
    {
        public void Configure(EntityTypeBuilder<LgpdCliente> builder)
        {
            builder.ToTable("lgpd_solicitacoes");

            builder.HasKey(f => f.Id)
                .HasName("PRIMARY");

            builder.Property(f => f.Id)
                .HasColumnName("id");

            builder.Property(f => f.Nome)
                .HasColumnName("nome")
                .HasMaxLength(100);

            builder.Property(f => f.Telefone)
                .HasColumnName("telefone")
                .HasMaxLength(15);

            builder.Property(f => f.Endereco)
                .HasColumnName("endereco")
                .HasMaxLength(100);

            builder.Property(f => f.RemoverInformacoesPagamento)
                .HasColumnName("removerinformacoespagamento");
        }
    }
}
