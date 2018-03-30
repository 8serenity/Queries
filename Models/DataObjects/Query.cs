using System;

namespace Models.DataObjects
{
    public class Query
    {
        public virtual int Id { get; set; }
        public virtual string QueryText { get; set; }
        public virtual DateTime DateWritten { get; set; }
        public virtual int UserId { get; set; }
        public virtual int QueryStatus { get; set; }
    }
}