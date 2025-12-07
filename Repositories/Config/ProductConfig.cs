using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.ProductPrice).IsRequired();

            builder.HasData(
                 new Product() { ProductId = 1, CategoryId = 1, ImageUrl = "/images/5.png", ProductName = "Eski Türk Tarzı Düğün Paketi", ProductPrice = 500_000, ShowCase = true },
                new Product() { ProductId = 2, CategoryId = 1, ImageUrl = "/images/3.png", ProductName = "Fransız Düğün Paketi", ProductPrice = 300_000, ShowCase = true },
                new Product() { ProductId = 3, CategoryId = 1, ImageUrl = "/images/2.png", ProductName = "İskandinav Düğün Paketi", ProductPrice = 400_000, ShowCase = true },
                new Product() { ProductId = 4, CategoryId = 3, ImageUrl = "/images/ottomanweddingchair.png", ProductName = "Sandalye 1x100", ProductPrice = 1_000, ShowCase = false },
                new Product() { ProductId = 5, CategoryId = 3, ImageUrl = "/images/8.png", ProductName = "Sandalye 2x100", ProductPrice = 1_000, ShowCase = false },
                new Product() { ProductId = 6, CategoryId = 3, ImageUrl = "/images/9.png", ProductName = "Sandalye 3x100", ProductPrice = 100, ShowCase = false },
                new Product() { ProductId = 7, CategoryId = 3, ImageUrl = "/images/10.png", ProductName = "Masa 1x25", ProductPrice = 1_000, ShowCase = false },
                new Product() { ProductId = 8, CategoryId = 3, ImageUrl = "/images/11.png", ProductName = "Masa 2x25", ProductPrice = 1_000, ShowCase = false },
                new Product() { ProductId = 9, CategoryId = 3, ImageUrl = "/images/12.png", ProductName = "Masa 3x25", ProductPrice = 1_000, ShowCase = false },
                new Product() { ProductId = 10, CategoryId = 2, ImageUrl = "/images/13.png", ProductName = "Düğün Salonu 1", ProductPrice = 10_000, ShowCase = true },
                new Product() { ProductId = 11, CategoryId = 2, ImageUrl = "/images/16.png", ProductName = "Gemi Düğün Salonu 1", ProductPrice = 10_000, ShowCase = true },
                new Product() { ProductId = 12, CategoryId = 2, ImageUrl = "/images/14.png", ProductName = "Düğün Salonu 3", ProductPrice = 10_000, ShowCase = true },
                new Product() { ProductId = 13, CategoryId = 2, ImageUrl = "/images/17.png", ProductName = "Gemi Düğün Salonu 3", ProductPrice = 10_000, ShowCase = true },
                new Product() { ProductId = 14, CategoryId = 4, ImageUrl = "/images/18.png", ProductName = "Pasta 1", ProductPrice = 2_000, ShowCase = true },
                new Product() { ProductId = 15, CategoryId = 4, ImageUrl = "/images/19.png", ProductName = "Pasta 2", ProductPrice = 2_000, ShowCase = false },
                new Product() { ProductId = 16, CategoryId = 4, ImageUrl = "/images/20.png", ProductName = "Pasta 3", ProductPrice = 2_000, ShowCase = false }
            );
        }
    }
}