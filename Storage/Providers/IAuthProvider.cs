using Storage.Core.Object;
using Storage.Models;

namespace Storage.Providers
{
    public interface IAuthProvider
    {
        bool IsLoggedIn { get; }
        bool Login(UserModel model);
        int SearchUser(string name);
        bool Register(RegisterModel model);
        void Logout();
    }
}
