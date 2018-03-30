using System.Collections.Generic;

namespace Models.DataObjects
{
    public class Status
    {
        public virtual int Id { get; set; }
        public string StatusDescription { get; set; }
        public virtual IList<Query> Queries { get; set; }

        public Status()
        {
            Queries = new List<Query>();
        }
    }
}