using BlazorWebAppRGPC.Model;
using BlazorWebAppRGPC.Repository.IRepository;
using NHibernate;
using NHibernate.Linq;

namespace BlazorWebAppRGPC.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly ISessionFactory _session;

        public ClassRepository(ISessionFactory session)
        {
            _session = session;
        }
        public List<Class> GetAllClasses()
        {
            using (var session = _session.OpenSession())
            {
                return session.Query<Class>()
                    .Fetch(x=>x.Teacher)
                    .ToList();
            }
        }

        public Class GetClassById(int id)
        {
            using (var session = _session.OpenSession())
            {
                return session.Query<Class>().Where(x => x.Id == id).FirstOrDefault();
            }
        }
    }
}
