using FunInMotion.Gif.SharedCommon;
using FunInMotion.Gif.SharedCommon.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FunInMotion.Gif.Model
{
    public class User : IStateObject
    {
        public int UserId { get;  set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Login name is required")]
        [Display(Name = "Login Name")]
        public string Login { get;  set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password name is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum of 6 characters")]
        public string Password { get;  set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Firstname is required")]
        [Display(Name = "Firstname")]
        public string Firstname { get;  set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Lastname is required")]
        [Display(Name = "Lastname")]
        public string Lastname { get;  set; }

        public ICollection<UserImageModel> Images { get; set; }

        public ObjectState State
        {
            get; private set;
        }
    }
}
