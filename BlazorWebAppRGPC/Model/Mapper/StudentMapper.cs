using Share;
using BlazorWebAppRGPC.Model.DTO;

namespace BlazorWebAppRGPC.Model.Mapper
{
    public class StudentMapper
    {
        public StudentGrpc StudentToStudentGrpc(Student _student)
        {
            StudentGrpc studentGrpc = new StudentGrpc();
            studentGrpc.Id = _student.Id;
            studentGrpc.Name = _student.Name;
            studentGrpc.Address = _student.Address;
            studentGrpc.Dob = _student.Dob;
            studentGrpc.ClassId = _student.ClassStudent.Id;
            return studentGrpc;
        }
        public Student StudentGrpcToStudent(StudentGrpc studentGrpc)
        {
            Student _student = new Student();
            _student.Id = studentGrpc.Id;
            _student.Name = studentGrpc.Name;
            _student.Address = studentGrpc.Address;
            _student.Dob = studentGrpc.Dob;
            _student.ClassStudent = _classRepository.GetClassById(studentGrpc.ClassId);
            return _student;
        }
        
    }
}
