using System.Linq;
using System.Web;
using System.Web.Security;
using Storage.Core;
using Storage.Core.Object;
using Storage.Models;

namespace Storage.Providers
{
    public class AuthProvider : IAuthProvider
    {
        private readonly IUserRepository _userRepository;
        public AuthProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool IsLoggedIn
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }
        public bool Login(string name, string password)
        {
            var list = new ListUser(_userRepository);
            User user = null;
            user = list.Users.FirstOrDefault(u => u.Name == name && u.Password == password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(name, false);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Register(string name, string password)
        {
            var list = new ListUser(_userRepository);
            User user = null;
            user = list.Users.FirstOrDefault(u => u.Name == name && u.Password == password);
            if (user == null)
            {
                _userRepository.RegUser(new User { Name = name, Password = password });
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
