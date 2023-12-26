using Share;
using SimpleGRPC.Repository;
using SimpleGRPC.Repository.IRepository;

namespace SimpleGRPC.Model.Mapper
{
    public class ClassMapper
    {
        public ClassGrpc ClassToClassGrpc(Class classs)
        {
            ClassGrpc classGrpc = new ClassGrpc();
            classGrpc.Id = classs.Id;
            classGrpc.Name = classs.Name;
            classGrpc.Subject = classs.SubjectName;
            classGrpc.TeacherId = classs.Teacher.Id;
            classGrpc.TeacherName = classs.Teacher.Name;
            return classGrpc;
        }
        public Class ClassGrpcToClass(ClassGrpc classGrpc)
        {
            Class _class = new Class();
            _class.Id = classGrpc.Id;
            _class.Name = classGrpc.Name;
            _class.SubjectName = classGrpc.Subject;
            if(classGrpc.TeacherId != -1 && classGrpc.TeacherId != 0)
            {
                _class.Teacher = new Teacher
                {
                    Id = classGrpc.TeacherId,
                };
            }
            return _class;
        }
    }
}
