using System.ComponentModel.DataAnnotations;

namespace Demo_Product.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen bir isim giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen bir soyad giriniz")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Lütfen bir kullanıcı adı giriniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen bir şifre giriniz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen bir şifre giriniz")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen şifreyi dogrulayınız giriniz")]
        [Compare("Password",ErrorMessage ="Lütfen şifrelerin eşleştigine emin olun")]
        public string ConfirmPassword { get; set; }
    }
}
