using System.ComponentModel.DataAnnotations;

namespace Identity.Web.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Role İsmi")]
        [Required(ErrorMessage = "Role ismi gereklidir.")]
        public string Name { get; set; }
    }
}
