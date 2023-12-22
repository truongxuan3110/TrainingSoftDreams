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
using Share;
using System.Drawing.Printing;

namespace SimpleGRPC.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly ISessionFactory _session;

        public ClassRepository(ISessionFactory session)
        {
            _session = session;
        }

        public BooleanGrpc AddNewClass(Class classNew)
        {
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    BooleanGrpc r = new BooleanGrpc();
                    try
                    {
                        classNew.Id = GetIDNewClass(); 
                        session.Insert(classNew);
                        transaction.Commit();
                        r.result = true;
                        r.mess = "Successfull";
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        r.result = false;
                        r.mess = ex.Message;
                        transaction.Rollback();
                    }
                    return r;
                }
            }
        }
        public BooleanGrpc UpdateClass(Class classUpdate)
        {
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    BooleanGrpc r = new BooleanGrpc();
                    try
                    {
                        session.Update(classUpdate);
                        transaction.Commit();
                        r.result = true;
                        r.mess = "Successfull";
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        r.result = false;
                        r.mess = ex.Message;
                        transaction.Rollback();
                    }
                    return r;
                }
            }
        }

        public BooleanGrpc DeleteClass(Class classDelete)
        {
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    BooleanGrpc r = new BooleanGrpc();
                    try
                    {
                        session.Delete(classDelete);
                        transaction.Commit();
                        r.result = true;
                        r.mess = "Successfull";
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        r.result = false;
                        r.mess = ex.Message;
                        transaction.Rollback();
                    }
                    return r;
                }
            }
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
            try
            {
                using (var session = _session.OpenSession())
                {
                    var c = session.Query<Class>().Max(c => c.Id);
                    return c + 1;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public List<Class> GetDataPage(int pageNumber, int pageSize, Class classSearch)
        {
            using (var session = _session.OpenSession())
            {
                try
                {
                    var query = session.Query<Class>();
                    query = Filter(query, classSearch);
                    return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                }
                catch (Exception ex)
                {
                    throw;
                }
                
            }
        }
        private IQueryable<Class> Filter(IQueryable<Class> query, Class classSearch)
        {
            if (!string.IsNullOrWhiteSpace(classSearch.Name))
            {
                query = query.Fetch(s => s.Teacher).Where(x => x.Name.Contains(classSearch.Name));
            }
            if (!string.IsNullOrWhiteSpace(classSearch.SubjectName))
            {
                query = query.Fetch(s => s.Teacher).Where(x => x.SubjectName.Contains(classSearch.SubjectName));
            }
            if (classSearch.Teacher != null)
            {
                query = query.Fetch(s => s.Teacher).Where(x => x.Teacher.Id == classSearch.Teacher.Id);
            }
            return query;
        }
    }
}
