using Storage.Core.Object;
using System.Collections.Generic;

namespace Storage.Core
{
    public interface IUserRepository
    {
        IList<User> GetUserList();
        void RegUser(User user);
    }
}
