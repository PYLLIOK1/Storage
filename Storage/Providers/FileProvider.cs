using Storage.Core;
using Storage.Core.Object;
using System;

namespace Storage.Providers
{
    public class FileProvider : IFileProvider
    {
        private readonly IFileRepository _fileRepository;
        public FileProvider(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        public void AddFileUser(string name, DateTime date, string author, string ico, string path)
        {
            _fileRepository.Add(new File { Name = name, Author = author, DateTime = date, Path = path, Ico = ico });
        }
    }
}