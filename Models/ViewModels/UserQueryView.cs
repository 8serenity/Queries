using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class UserQueryView
    {
        [Display(Name = "Номер обращения")]
        public virtual int Id { get; set; }


        [Display(Name = "Текст обращения")]
        public virtual string QueryText { get; set; }

        [Display(Name = "Дата подачи")]
        public virtual DateTime DateWritten { get; set; }

        [Display(Name = "Статус заявки")]
        public virtual int QueryStatus { get; set; }
    }
}