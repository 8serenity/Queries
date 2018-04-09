using FluentNHibernate.Mapping;
using Models.DataObjects;

namespace DataAccessLayer.NHibernate
{
    public class QueryMap : ClassMap<Query>
    {
        public QueryMap()
        {
            Id(x => x.Id);
            Map(x => x.QueryText);
            Map(x => x.DateWritten);
            References(x => x.User, "UserId");
            Map(x => x.QueryStatus);
            Table("Queries");
        }
    }
}
