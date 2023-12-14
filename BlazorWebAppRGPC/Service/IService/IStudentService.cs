using BlazorWebAppRGPC.Model;

namespace BlazorWebAppRGPC.Service.IService
{
    interface IStudentService
    {
        public List<Student> GetAllStudents();

        public void AddNewStudent(Student student);

        public void UpdateStudent(Student studentUpdate);

        public void DeleteStudent(Student student);

        public List<Student> SortData();

        public Student GetStudentById(int id);
        public int GetIDNewStudent();
    }
}
