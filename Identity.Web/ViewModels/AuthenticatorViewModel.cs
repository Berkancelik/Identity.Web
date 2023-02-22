using Identity.Web.Enums;
using System.ComponentModel.DataAnnotations;

namespace Identity.Web.ViewModels
{
    public class AuthenticatorViewModel
    {
        public string SharedKey { get; set; }
        public string AuthenticationUri { get; set; }

        [Display(Name ="Doğrulama Kodunuz")]
        [Required(ErrorMessage ="Doğrulama kodu gereklidir")]
        public string VerificationCode { get; set; }
        public TwoFactor TwoFactorType { get; set; }
    }
}
