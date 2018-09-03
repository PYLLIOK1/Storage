using Storage.Core.Object;
using Storage.Models;

namespace Storage.Providers
{
    public interface IAuthProvider
    {
        bool IsLoggedIn { get; }
        bool Login(string name, string password);
        int SearchUser(string name);
        bool Register(string name, string password);
        void Logout();
    }
}
