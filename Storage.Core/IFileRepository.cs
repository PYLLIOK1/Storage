using Storage.Core.Object;
using System.Collections.Generic;

namespace Storage.Core
{
    public interface IFileRepository
    {
        IList<File> GetFileList();
        void Add(File file);
    }
}
