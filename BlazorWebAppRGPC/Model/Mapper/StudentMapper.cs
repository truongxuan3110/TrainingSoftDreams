using Share;
using BlazorWebAppRGPC.Model.DTO;
using BlazorWebAppRGPC.Repository.IRepository;

namespace BlazorWebAppRGPC.Model.Mapper
{
    public class StudentMapper
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        public StudentMapper(IStudentRepository studentRepository, IClassRepository classRepository)
        {
            _studentRepository = studentRepository;
            _classRepository = classRepository;
        }
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
            //_student.ClassStudent = _classRepository.GetClassById(studentGrpc.ClassId);
            return _student;
        }
        public StudentViewDTO StudentToStudentViewDTO(Student student)
        {
            StudentViewDTO studentViewDTO = new StudentViewDTO();
            studentViewDTO.Name = student.Name;
            studentViewDTO.Address = student.Address;
            studentViewDTO.ClassName = _classRepository.GetClassById(student.ClassStudent.Id).Name;
            studentViewDTO.Dob = student.Dob.ToString("dd/MM/yyyy");
            studentViewDTO.Id = student.Id;
            return studentViewDTO;

        }
        public Student StudentDTOToStudent(StudentDTO studentDTO, bool isCreate)
        {
            Student student;
            if (isCreate)
            {
                student = new Student();
                student.Id = _studentRepository.GetIDNewStudent();
                student.Name = studentDTO.Name;
                student.Address = studentDTO.Address;
                student.ClassStudent = _classRepository.GetClassById(studentDTO.ClassId);
                student.Dob = studentDTO.Dob;
                return student;
            }
            if(!isCreate)
            {
                student = _studentRepository.GetStudentById(studentDTO.Id);
                student.Name = studentDTO.Name;
                student.Address = studentDTO.Address;
                student.Dob = studentDTO.Dob;
                student.ClassStudent = _classRepository.GetClassById(studentDTO.ClassId);
                return student;
            }
            return null;
        }
        public List<StudentViewDTO> listStudentToListStudentViewDTO(List<Student> students)
        {
            List<StudentViewDTO> studentViewDTOs = new List<StudentViewDTO>();
            foreach(Student student in students)
            {
                StudentViewDTO s = StudentToStudentViewDTO(student); studentViewDTOs.Add(s);
            }
            return studentViewDTOs;
        }
        
    }
}
