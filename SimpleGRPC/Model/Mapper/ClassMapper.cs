using Share;
using SimpleGRPC.Repository;
using SimpleGRPC.Repository.IRepository;

namespace SimpleGRPC.Model.Mapper
{
    public class ClassMapper
    {
        ITeacherRepository teacherRepository { get; set; }
        public ClassMapper(ITeacherRepository _teacherRepository)
        {
            this.teacherRepository = _teacherRepository;
        }
        public ClassGrpc ClassToClassGrpc(Class _class)
        {
            ClassGrpc classGrpc = new ClassGrpc();
            classGrpc.Id = _class.Id;
            classGrpc.Name = _class.Name;
            classGrpc.Subject = _class.SubjectName;
            classGrpc.TeacherId = _class.Teacher.Id;
            return classGrpc;
        }
        public Class ClassGrpcToClass(ClassGrpc classGrpc)
        {
            Class _class = new Class();
            _class.Id = classGrpc.Id;
            _class.Name = classGrpc.Name;
            _class.SubjectName = classGrpc.Subject;
            _class.Teacher = teacherRepository.GetTeacherById(classGrpc.TeacherId);
            return _class;
        }
    }
}
