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
        public bool Login(UserModel model)
        {
            var list = new ListUser(_userRepository);
            User user = null;
            user = list.Users.FirstOrDefault(u => u.Name == model.Name && u.Password == model.Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(model.Name, false);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int SearchUser(string name)
        {
            var list = new ListUser(_userRepository);
            User user = null;
            user = list.Users.FirstOrDefault(u => u.Name == name);
            return user.Id;
        }
        public bool Register(RegisterModel model)
        {
            var list = new ListUser(_userRepository);
            User user = null;
            user = list.Users.FirstOrDefault(u => u.Name == model.Name && u.Password == model.Password);
            if (user == null)
            {
                _userRepository.RegUser(new User { Name = model.Name, Password = model.Password });
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
