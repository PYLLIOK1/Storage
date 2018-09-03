using Storage.Core.Object;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using System;

namespace Storage.Core
{
    public class FileRepository : IFileRepository
    {
        private readonly ISession _session;
        public FileRepository(ISession session)
        {
            _session = session;
        }
        public IList<File> GetFileList()
        {
            int num = 30;
            var Files = _session.Query<File>();
            foreach (var b in Files)
            {
                if (b.Name.Length > num)
                {
                    b.Name = b.Name.Substring(0, num) + "...";
                }
            }
            return Files.ToList();
        }
        public void Add(string name, DateTime date, int author, string ico, string path)
        {
            string sql = "IF (OBJECT_ID('FileAdd') IS NOT NULL) DROP PROCEDURE FileAdd";
            IQuery query = _session.CreateSQLQuery(sql);
            int a = query.ExecuteUpdate();
            sql = "CREATE PROCEDURE[dbo].[FileAdd](@Name nvarchar(255), @DateTime datetime2(7), @Path nvarchar(255), @Ico nvarchar(255), @Author int) AS BEGIN INSERT INTO Document(Name, DateTime, Path, Ico, Author_id)VALUES(@Name, @DateTime, @Path, @Ico, @Author)END";
            query = _session.CreateSQLQuery(sql);
            a = query.ExecuteUpdate();
            query = _session.CreateSQLQuery("exec FIleAdd :Name, :Data, :Path, :Ico, :Author");
            query.SetParameter("Name", name);
            query.SetParameter("Data", date);
            query.SetParameter("Path", path);
            query.SetParameter("Ico", ico);
            query.SetParameter("Author", author);
            a = query.ExecuteUpdate();
        }
    }
}
