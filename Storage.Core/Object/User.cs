using System.Collections.Generic;

namespace Storage.Core.Object
{
    public class User
    {
        public virtual int Id{ get; set; }
        public virtual string Name{ get; set; }
        public virtual string Password{ get; set; }
        private IList<File> _files;
        public virtual IList<File> Files
        {
            get
            {
                return _files ?? (_files = new List<File>());
            }
            set { _files = value; }
        }
    }
}
