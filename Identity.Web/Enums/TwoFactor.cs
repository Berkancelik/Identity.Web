using System.ComponentModel.DataAnnotations;

namespace Identity.Web.Enums
{
    public enum TwoFactor
    {
        [Display(Name = "Hiç Biri")]
        None = 0,

        [Display(Name = "Telefom ile kimlik doğrulama")]
        Phone = 1, 

        [Display(Name = "Email ile kimlik doğrulama")]
        Email = 2, 

        [Display(Name = "Microsoft-Google Authenticator ile kimlik doğrulama")]
        MicrosoftGoogle = 3,

    }
}
