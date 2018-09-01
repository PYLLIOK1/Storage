using Storage.Core.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Storage.Providers
{
    public interface IFileProvider
    {
       void AddFileUser(string name, DateTime date, string author, string ico, string path);
    }
}
