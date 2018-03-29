using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Queries.Models.NHibernate
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