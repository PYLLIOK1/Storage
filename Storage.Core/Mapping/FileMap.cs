using FluentNHibernate.Mapping;
using Storage.Core.Object;

namespace Storage.Core.Mapping
{
    public class FileMap: ClassMap<File>
    {
        public FileMap()

        {
            Table("Document");
            Id(x => x.Id);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.DateTime).Not.Nullable();
            Map(x => x.Path);
            Map(x => x.Ico);
            Map(x => x.Author);
        }
    }
}
