using Storage.Core;
using Storage.Core.Object;
using System.Collections.Generic;
using System.Linq;
namespace Storage.Models
{

    public class ListViewSearchModel
    {
        public ListViewSearchModel(IFileRepository _fileRepository, string search)
        {
            Files = _fileRepository.GetFileList().Where(x => x.Name.Contains(search) || x.Author.Contains(search) || x.DateTime.ToString().Contains(search)).ToList();
        }
        public IList<File> Files { get; set; }
    }
}