using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Queries.Models
{
    public class UserLoginView
    {
        [Display(Name = "E-mail")]
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