using Storage.Core;
using Storage.Core.Object;
using System.Collections.Generic;
using System.Linq;

namespace Storage.Models
{
    public class ListViewModel
    {
        public ListViewModel(IFileRepository _fileRepository)
        {
            Files = _fileRepository.GetFileList();
        }
        public IList<File> Files { get; set; }
    }
    public class ListViewSearchModel
    {
        public ListViewSearchModel(IFileRepository _fileRepository, string search, string searchid)
        {
            if (searchid == "1")
            {
                Files = _fileRepository.GetFileList().Where(x => x.Name.Contains(search) || x.Author.Contains(search) || x.DateTime.ToString().Contains(search)).ToList();
                Files = Files.OrderBy(x => x.Name).ToList();
            }
            else if (searchid == "2")
            {
                Files = _fileRepository.GetFileList().Where(x => x.Name.Contains(search) || x.Author.Contains(search) || x.DateTime.ToString().Contains(search)).ToList();
                Files = Files.OrderBy(x => x.Author).ToList();
            }
            else if (searchid == "3")
            {
                Files = _fileRepository.GetFileList().Where(x => x.Name.Contains(search) || x.Author.Contains(search) || x.DateTime.ToString().Contains(search)).ToList();
                Files = Files.OrderBy(x => x.DateTime).ToList();
            }
            else if (searchid == "4")
            {
                Files = _fileRepository.GetFileList().Where(x => x.Name.Contains(search) || x.Author.Contains(search) || x.DateTime.ToString().Contains(search)).ToList();
                Files = Files.OrderByDescending(x => x.Name).ToList();
            }
            else if (searchid == "5")
            {
                Files = _fileRepository.GetFileList().Where(x => x.Name.Contains(search) || x.Author.Contains(search) || x.DateTime.ToString().Contains(search)).ToList();
                Files = Files.OrderByDescending(x => x.Author).ToList();
            }
            else if (searchid == "6")
            {
                Files = _fileRepository.GetFileList().Where(x => x.Name.Contains(search) || x.Author.Contains(search) || x.DateTime.ToString().Contains(search)).ToList();
                Files = Files.OrderByDescending(x => x.DateTime).ToList();
            }
            else 
            {
                Files = _fileRepository.GetFileList().Where(x => x.Name.Contains(search) || x.Author.Contains(search) || x.DateTime.ToString().Contains(search)).ToList();
            }
        }
        public IList<File> Files { get; set; }
    }
}