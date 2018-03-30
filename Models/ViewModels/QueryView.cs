using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
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

        [DateOfBirth (MinAge =18, MaxAge = 150)]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false)]
        public virtual DateTime Birthdate { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public virtual string Email { get; set; }

        
        [Display(Name = "Текст обращения")]
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.MultilineText)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public virtual string QueryText { get; set; }

    }
}