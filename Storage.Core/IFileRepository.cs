using Storage.Core.Object;
using System;
using System.Collections.Generic;

namespace Storage.Core
{
    public interface IFileRepository
    {
        IList<File> GetFileList();
        void Add(string name, DateTime date, int author, string ico, string path);
    }
}
