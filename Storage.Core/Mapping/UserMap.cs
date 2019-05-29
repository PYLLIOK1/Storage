using Storage.Core.Object;
using FluentNHibernate.Mapping;

namespace Storage.Core.Mapping
{
    public class UserMap:ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.Id);
            Map(x => x.Name)
                .Length(50)
                .Not.Nullable();
            Map(x => x.Password)
                .Length(50)
                .Not.Nullable();
            HasMany(x => x.Files)
                .Inverse();
        }
    }
}
