using System.ComponentModel.DataAnnotations;

namespace Identity.Web.ViewModels
{
    public class UserViewModel
    {

        [Required(ErrorMessage = "Kullanıcı ismi gereklidir")]
        [Display(Name ="Kullanıcı Adı")]
        public string UserName { get; set; }

        [Display(Name = "Tel No")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Adresi gereklidir")]
        [Display(Name = "Email Adresi")]
        [EmailAddress(ErrorMessage = "Email adresiniz doğru fotrmatta değildir")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifreniz gereklidir")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
