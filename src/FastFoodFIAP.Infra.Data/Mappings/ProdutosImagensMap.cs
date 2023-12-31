using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

using FastFoodFIAP.Domain.Models.ProdutoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodFIAP.Infra.Data.Mappings
{
    public class ProdutosImagensMap: IEntityTypeConfiguration<Imagem>
    {
        public void Configure(EntityTypeBuilder<Imagem> builder)
        {            
            builder.ToTable("produtos_imagens");

            builder.HasKey(c => c.Id)
                .HasName("PRIMARY");

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Url)
                .HasColumnName("url")
                .HasMaxLength(300); 

            builder.Property(c => c.ProdutoId)
                .HasColumnName("produto_id");

            builder.HasOne(c => c.ProdutoNavigation)
                .WithMany(e => e.Imagens)
                .HasForeignKey( c => c.ProdutoId)
                .OnDelete(DeleteBehavior.Cascade);            
        }
    }
}