using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ProductDto
    {
        public int ProductId { get; init; }
        
        [Required(ErrorMessage = "Ürün adı gerekli.")]
        public String? ProductName { get; init; } = String.Empty;

        [Required(ErrorMessage = "Fiyat bilgisi gerekli.")]
        public decimal ProductPrice { get; init; }
        public String? Summary { get; init; } = String.Empty;
        public String? ImageUrl { get; set; }
        public int? CategoryId { get; init; }  
        
    }
}