using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Queries.Models
{
    public class QueryView
    {

        [Display(Name = "Имя")]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public virtual string Name { get; set; }

        
        [Display(Name = "Фамилия")]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public virtual string Surname { get; set; }

        
        [Display(Name = "E-mail")]
        [EmailAddress]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public virtual string Email { get; set; }

        
        [Display(Name = "Текст обращения")]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public virtual string QueryText { get; set; }

    }
}