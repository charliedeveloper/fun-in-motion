using System.ComponentModel.DataAnnotations;

namespace FunInMotion.Gif.Model
{
    public class UseViewModel
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Login name is required")]
        [Display(Name = "Login Name")]
        public string Login { get;  set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage ="Minimum of 6 characters")]
        public string Password { get;  set; }
    }
}
