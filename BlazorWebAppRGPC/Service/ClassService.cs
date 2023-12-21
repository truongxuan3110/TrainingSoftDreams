using BlazorWebAppRGPC.Model;
using BlazorWebAppRGPC.Model.DTO;
using BlazorWebAppRGPC.Model.Mapper;
using BlazorWebAppRGPC.Service.IService;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using Share;

namespace BlazorWebAppRGPC.Service
{
    public class ClassService : IClassService
    {
        ClassMapper classMapper = new ClassMapper();
        TeacherMapper teacherMapper = new TeacherMapper();
        public ClassProto getService()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress($"http://localhost:5141", new GrpcChannelOptions { HttpHandler = httpHandler });
            //var channel = GrpcChannel.ForAddress("https://localhost:7291", new GrpcChannelOptions { HttpHandler = httpHandler });
            return channel.CreateGrpcService<ClassProto>();
        }   
        public void AddNewClass(ClassDTO classNew)
        {
                var client = getService();
                Empty empty = new Empty();
                ClassGrpc classGrpc = classMapper.ClassDTOToClassGrpc(classNew);
                client.AddClass(classGrpc);
        }

        public void DeleteClass(Class classDelete)
        {
            throw new NotImplementedException();
        }

        public List<ClassViewDTO> GetAllClasss()
        {
            List<ClassViewDTO> listClasses = new List<ClassViewDTO>();
            var client = getService();
            Empty empty = new Empty();
            var list = client.GetListClass(empty);
            foreach (var c in list.List)
            {
                ClassViewDTO s = classMapper.ClassGrpcToClassViewDTO(c);
                listClasses.Add(s);
            }
            return listClasses;
        }

        public Class GetClassById(int id)
        {
            Empty e = new Empty();
            var client = getService();
            var t = client.GetClassById(teacherMapper.ToIntGrpc(id));
            return classMapper.ClassGrpcToClass(t);
        }

        public int GetIDNewClass()
        {
            throw new NotImplementedException();
        }

        public List<Class> SortData()
        {
            throw new NotImplementedException();
        }

        public void UpdateClass(Class classUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
