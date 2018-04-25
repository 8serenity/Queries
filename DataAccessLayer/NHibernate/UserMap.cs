using FluentNHibernate.Mapping;
using Models.DataObjects;

namespace DataAccessLayer.NHibernate
{
    public class UserMap : ClassMap<AppUser>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.Email);
            Map(x => x.EmailConfirmed);
            Map(x => x.PasswordHash);
            Map(x => x.SecurityStamp);
            Map(x => x.PhoneNumber);
            Map(x => x.PhoneNumberConfirmed);
            Map(x => x.TwoFactorEnabled);
            Map(x => x.LockoutEndDateUtc).Nullable();
            Map(x => x.LockoutEnabled);
            Map(x => x.AccessFailedCount);
            Map(x => x.UserName);
            Map(x => x.Name);
            Map(x => x.Surname);
            Map(x => x.Birthdate).Nullable();
            Table("AspNetUsers");
            HasMany(x => x.Queries).KeyColumn("Id");
        }
    }
}
