using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ResetPasswordDto
    {
        public String? UserName { get; init; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Şifre gerekli.")]
        public String? Password { get; init; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Şifre onayla gerekli.")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor.")]
        public String? ConfirmPassword { get; init; }
    }
}