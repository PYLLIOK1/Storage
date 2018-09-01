using Storage.Core.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Engine.Query;

namespace Storage.Core
{
    public class UserRepository : IUserRepository
    {
        private readonly ISession _session;
        public UserRepository(ISession session)
        {
            _session = session;
        }
        public IList<User> GetUserList()
        {
            return _session.Query<User>().ToList();
        }

        public void RegUser(User user)
        {
            string sql = "INSERT INTO Users (Name, Password) VALUES('log', 'pas')";
            sql = sql.Replace("log", user.Name).Replace("pas", user.Password);
            IQuery q = _session.CreateSQLQuery(sql);
            int a = q.ExecuteUpdate();
        }
    }
}
