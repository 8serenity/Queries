using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class UserLoginView
    {
        [Display(Name = "E-mail")]
        [EmailAddress]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public virtual string Email { get; set; }


        [Display(Name = "Пароль")]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DataType(DataType.Password)]
        public virtual string Password { get; set; }
    }
}