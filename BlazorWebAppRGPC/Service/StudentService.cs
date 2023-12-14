using BlazorWebAppRGPC.Model;
using BlazorWebAppRGPC.Model.Mapper;
using BlazorWebAppRGPC.Service.IService;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using Share;

namespace BlazorWebAppRGPC.Service
{
    public class StudentService : IStudentService
    {
        StudentMapper studentMapper = new StudentMapper();

        public void AddNewStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudents()
        {
            List<Student> listStudents = new List<Student>();
            var client = getService();
            Empty empty = new Empty();
            var list = client.GetListStudents(empty);
            foreach ( var student in list.List)
            {
                Student s = studentMapper.StudentGrpcToStudent(student);
                listStudents.Add(s);
            }
            return listStudents;
        }

        public int GetIDNewStudent()
        {
            throw new NotImplementedException();
        }

        public StudentProto getService()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress($"http://localhost:5141", new GrpcChannelOptions { HttpHandler = httpHandler });
            //var channel = GrpcChannel.ForAddress("https://localhost:7291", new GrpcChannelOptions { HttpHandler = httpHandler });
            return channel.CreateGrpcService<StudentProto>();
        }

        public Student GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> SortData()
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student studentUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
