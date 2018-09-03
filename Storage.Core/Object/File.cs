using System;

namespace Storage.Core.Object
{
    public class File
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime DateTime { get; set; }
        public virtual string Path { get; set; }
        public virtual string Ico { get; set; }
        public virtual User Author { get; set; }
    }
}
