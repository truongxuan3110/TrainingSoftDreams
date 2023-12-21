using Google.Protobuf.WellKnownTypes;
using SimpleGRPC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGRPC.Repository.IRepository
{
    public interface IClassRepository
    {
        public List<Class> GetAllClasses();
        public Class GetClassById(int id);
        public void AddNewClass(Class classNew);

        public Boolean UpdateClass(Class classUpdate);

        public void DeleteStudent(Class classDelete);
        public int GetIDNewClass();

    }
}
