using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DataObjects
{
    public class Query
    {
        public virtual int Id { get; set; }
        public virtual string QueryText { get; set; }
        public virtual DateTime DateWritten { get; set; }
        [ForeignKey("User")]
        public virtual string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public virtual int QueryStatus { get; set; }
    }
}