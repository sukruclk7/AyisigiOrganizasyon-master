using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c=>c.CategoryId);
            builder.Property(c=>c.CategoryName).IsRequired();
            
            builder.HasData(
                new Category() { CategoryId = 1, CategoryName = "Düğün Paketileri" },
                new Category() { CategoryId = 2, CategoryName = "Salonlar" },
                new Category() { CategoryId = 3, CategoryName = "Düğün Eşyaları" },
                new Category() { CategoryId = 4, CategoryName = "Pastalar" }
            );
        }
    }
}