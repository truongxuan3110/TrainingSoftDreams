using BlazorWebAppRGPC.Model.DTO;
using BlazorWebAppRGPC.Service;
using BlazorWebAppRGPC.Service.IService;
using Share;

namespace BlazorWebAppRGPC.Model.Mapper
{
    public class ClasssMapper
    {
        ITeacherService teacherService = new TeacherService();
        public Class ClassGrpcToClass(ClassGrpc classGrpc)
        {
            Class _class = new Class();
            _class.Id = classGrpc.Id;
            _class.Name = classGrpc.Name;
            _class.SubjectName = classGrpc.Subject;
            _class.Teacher = teacherService.GetTeacherById(classGrpc.TeacherId);
            return _class;
        }
        public ClassViewDTO ClassGrpcToClassViewDTO(ClassGrpc classGrpc)
        {
            ClassViewDTO _class = new ClassViewDTO();
            _class.Id = classGrpc.Id;
            _class.Name = classGrpc.Name;
            _class.SubjectName = classGrpc.Subject;
            _class.TeacherName = teacherService.GetTeacherById(classGrpc.TeacherId).Name;
            _class.TeacherId = classGrpc.TeacherId;
            return _class;
        }
        public ClassGrpc ClassViewDTOToClassGrpc(ClassViewDTO classViewDTO)
        {
            ClassGrpc classGrpc = new ClassGrpc();
            classGrpc.Id = classViewDTO.Id;
            classGrpc.Name = classViewDTO.Name;
            classGrpc.Subject = classViewDTO.SubjectName;
            classGrpc.TeacherId= classViewDTO.TeacherId;
            return classGrpc;
        }
        public ClassGrpc ClassDTOToClassGrpc(ClassDTO classDTO)
        {
            ClassGrpc classGrpc = new ClassGrpc();
            classGrpc.Id = classDTO.Id; 
            classGrpc.Name = classDTO.Name;
            classGrpc.Subject = classDTO.SubjectName;
            classGrpc.TeacherId = classDTO.TeacherId;
            return classGrpc;
        }
        public ClassDTO ClassToClassDTO(Class @class, bool isCreate)
        {
            if (isCreate)
            {
                return new ClassDTO();
            }
            else
            {
                ClassDTO _class = new ClassDTO();
                _class.Id = @class.Id;
                _class.Name = @class.Name;
                _class.SubjectName = @class.SubjectName;
                _class.TeacherId = @class.Teacher.Id;
                return _class;
            }
        }
    }
}
