﻿using FluentNHibernate.Mapping;
using Models.DataObjects;

namespace DataAccessLayer.NHibernate
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Surname);
            Map(x => x.Email);
            Map(x => x.Password);
            Map(x => x.Birthdate);
            Table("Users");
            HasMany(x => x.Queries).KeyColumn("Id");
        }
    }
}
