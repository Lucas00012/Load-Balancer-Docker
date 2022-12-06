using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mvc1.Models;

namespace Mvc1.Infrastructure.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Valor)
                .HasColumnType("decimal(18,2)");

            builder.HasData(new[]
            {
                new Produto { Id = 1, Nome = "Geladeira", Descricao = "Brastemp", Valor = 2000m },
                new Produto { Id = 2, Nome = "Fogão", Descricao = "4 bocas", Valor = 1200m },
                new Produto { Id = 3, Nome = "TV", Descricao = "Smart TV", Valor = 2700m }
            });
        }
    }
}
