using Identity.Web.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Identity.Web.ViewModels
{
    public class UserViewModel
    {

        [Required(ErrorMessage = "Kullanıcı ismi gereklidir")]
        [Display(Name ="Kullanıcı Adı")]
        public string UserName { get; set; }


        [Display(Name = "Tel No")]
        [RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$", ErrorMessage ="Telefon Numarası uygun forrtmatta değil")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Adresi gereklidir")]
        [Display(Name = "Email Adresi")]
        [EmailAddress(ErrorMessage = "Email adresiniz doğru fotrmatta değildir")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifreniz gereklidir")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)] 
        public string Password { get; set; }
        [DataType(DataType.Date)]

        [Display(Name = "Doğum Tarihi")]
        public DateTime? BirthDay { get; set; }
        [Display(Name = "Profil Resmi")]
        public string Picture { get; set; }
        [Display(Name = "Şehir")]
        public string City { get; set; }


        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }

    }
}
