using BlazorWebAppRGPC.Model.DTO;
using BlazorWebAppRGPC.Service;
using BlazorWebAppRGPC.Service.IService;
using Share;

namespace BlazorWebAppRGPC.Model.Mapper
{
    public class ClassMapper
    {
        ITeacherService teacherService = new TeacherService();
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
            return _class;
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
