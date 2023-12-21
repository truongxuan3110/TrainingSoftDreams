using SimpleGRPC.Model;
using SimpleGRPC.Repository.IRepository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using System.Data;

namespace SimpleGRPC.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly ISessionFactory _session;

        public ClassRepository(ISessionFactory session)
        {
            _session = session;
        }

        public void AddNewClass(Class classNew)
        {
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        var listClass = GetAllClasses();    
                        if(listClass.Count != 0)
                        {
                            classNew.Id = GetIDNewClass();
                        }
                        else
                        {
                            classNew.Id = 1;
                        }
                        session.Insert(classNew);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                    }
                }
            }
        }

        public void DeleteStudent(Class classDelete)
        {
            throw new NotImplementedException();
        }

        public List<Class> GetAllClasses()
        {
            using (var session = _session.OpenSession())
            {
                List<Class> classes = session.Query<Class>().Fetch(s=>s.Teacher).ToList();
                return classes;
            }
        }

        public Class GetClassById(int id)
        {
            using (var session = _session.OpenSession())
            {
                return session.Query<Class>()
                    .Where(s => s.Id == id).First();
            }
        }

        public int GetIDNewClass()
        {
            var c = GetAllClasses().OrderByDescending(x => x.Id).First();
            return c.Id + 1;
        }

        public bool UpdateClass(Class classUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
