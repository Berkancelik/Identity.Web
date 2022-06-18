using System.ComponentModel.DataAnnotations;

namespace Identity.Web.ViewModels
{
    public class PasswordResetByAdminViewModel
    {
        public string UserId { get; set; }

        [Display(Name = "Şifreniz")]
        public string NewPassword { get; set; }
    }
}
