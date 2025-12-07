using System.ComponentModel.DataAnnotations;

namespace AyisigiApp.Models
{
    public class LoginModel
    {
        private string? _returnurl;

        [Required(ErrorMessage = "isim gerekli.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Şifre gerekli.")]
        public string? Password { get; set; }

        public string ReturnUrl
        {
            get
            {
                if(_returnurl is null)
                    return "/";
                else
                    return _returnurl;
            }
            set
            {
                _returnurl = value;
            }
        }
    }
}