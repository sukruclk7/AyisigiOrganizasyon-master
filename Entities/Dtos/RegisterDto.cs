using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record RegisterDto
    {
        [Required(ErrorMessage = "Kullanıcı adı gerekli")]
        public String? UserName { get; init; }
        
        [Required(ErrorMessage = "Mail gerekli")]
        public String? Email { get; init; }
        
        [Required(ErrorMessage = "Şifre gerekli")]
        public String? Password { get; init; }
    }
}