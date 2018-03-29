using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Queries.Models.NHibernate
{
    public class QueryMap : ClassMap<Query>
    {
        public QueryMap()
        {
            Id(x => x.Id);
            Map(x => x.QueryText);
            Map(x => x.DateWritten);
            Map(x => x.UserId);
            Map(x => x.QueryStatus);
            Table("Queries");
        }
    }
}