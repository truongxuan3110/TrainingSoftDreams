using ProtoBuf.Grpc;
using Share;
using SimpleGRPC.Model;
using SimpleGRPC.Model.Mapper;
using SimpleGRPC.Repository;
using SimpleGRPC.Repository.IRepository;

namespace SimpleGRPC.Services
{
    public class ClassService : ClassProto
    {
        private readonly ILogger<ClassService> logger;
        private readonly IClassRepository _classRepository;
        private static ITeacherRepository teacherRepository;
        ClassMapper classMapper = new ClassMapper(teacherRepository);

        public ClassService(ILogger<ClassService> logger, IClassRepository classRepository, ITeacherRepository teacher)
        {
            this.logger = logger;
            _classRepository = classRepository;
            teacherRepository = teacher;
        }

        public Empty AddClass(ClassGrpc request, CallContext context = default)
        {
            Class classNew = classMapper.ClassGrpcToClass(request);
            _classRepository.AddNewClass(classNew);
            Empty empty = new Empty();
            return empty;
        }

        public Empty DeleteClass(Empty request, CallContext context = default)
        {
            throw new NotImplementedException();
        }

        public ListClasses GetListClass(Empty request, CallContext context = default)
        {
            ListClasses listClasses = new ListClasses();
            List<Class> classes = _classRepository.GetAllClasses();
            foreach (var item in classes)
            {
                ClassGrpc classGrpc = classMapper.ClassToClassGrpc(item);
                listClasses.List.Add(classGrpc);
            }
            return listClasses;
        }

        public Boolean UpdateClass(ClassGrpc classGrpc, Empty request, CallContext context = default)
        {
            throw new NotImplementedException();
        }

        public ClassGrpc GetClassById(IntGrpc id, CallContext context = default)
        {
            Class t = _classRepository.GetClassById(id.Id);
            return classMapper.ClassToClassGrpc(t);
        }
    }
}
