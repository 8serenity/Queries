using Queries.Models.NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Queries.Models
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