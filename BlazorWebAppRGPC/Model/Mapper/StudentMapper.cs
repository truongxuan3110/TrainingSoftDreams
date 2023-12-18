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
        public StudentDTO StudentToStudentDTO(Student student, bool isCreate)
        {
            StudentDTO studentDTO = new StudentDTO();
            if (isCreate)
            {
                return studentDTO;
            }
            else
            {
                studentDTO.Id = student.Id;
                studentDTO.Name = student.Name;
                studentDTO.Address = student.Address;
                studentDTO.Dob = student.Dob;
                studentDTO.ClassId = student.ClassStudent.Id;
                return studentDTO;
            }
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
