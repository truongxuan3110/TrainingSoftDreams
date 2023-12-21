using AntDesign;
using BlazorWebAppRGPC.Model;
using BlazorWebAppRGPC.Model.DTO;
using BlazorWebAppRGPC.Model.Mapper;
using BlazorWebAppRGPC.Repository;
using BlazorWebAppRGPC.Repository.IRepository;
using BlazorWebAppRGPC.Service.IService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Share;
using System.ServiceModel.Channels;

namespace BlazorWebAppRGPC.Pages
{
    public partial class ListStudent
    {
        private List<StudentViewDTO> listStudentViewDTO = new List<StudentViewDTO>();
        private List<Class> listClass = new List<Class>();
        public StudentSearch studentSearch = new StudentSearch();
        public Student student = new Student();
        public StudentDTO studentDTO = new StudentDTO();

        [Inject] StudentMapper studentMapper { get; set; }
        [Inject] IClassRepository classRepository { get; set; }

        private int pageNumber = 1;
        private int pageSize = 5;
        private int totalCount = 0;
        private PageView<Student> pageItems = new PageView<Student>();
        public bool isCreate = true;
        public bool isPopupVisible = false;
        protected override async Task OnInitializedAsync()
        {
            listClass = classRepository.GetAllClasses();
            await loadDataAsync();
        }
        private async Task loadDataAsync()
        {
            pageItems = await studentRepository.GetDataPage(pageNumber, pageSize,studentSearch);
            listStudentViewDTO = studentMapper.listStudentToListStudentViewDTO(pageItems.Items);
            totalCount = pageItems.PageCount;
            StateHasChanged();
        }
        private void ShowPopup(StudentViewDTO studentViewDTO)
        {
            isPopupVisible = true;
            if (studentViewDTO != null)
            {
                isCreate = false;
                student = studentRepository.GetStudentById(studentViewDTO.Id);
            }
            else
            {
                isCreate = true;
            }
            studentDTO = studentMapper.StudentToStudentDTO(student, isCreate);
        }
        public void Clear()
        {
            studentDTO = new StudentDTO();
            isCreate = true;
            studentSearch = new StudentSearch();

            UpdateListStudents();
        }
        private async void UpdateListStudents()
        {
            pageNumber = 1;
            await loadDataAsync();
        }
        public async Task OnPaging()
        {
            await loadDataAsync();
        }
        private async void OnValidSubmit()
        {
            pageNumber = 1;
            await loadDataAsync();
        }
        private void OnInvalidSubmit() { 
            studentSearch = new StudentSearch();
        }
        public void close()
        {
            Clear();
            isPopupVisible = false;
        }
        private void OnSubmitSuccess()
        {
            student = studentMapper.StudentDTOToStudent(studentDTO, isCreate);
            bool result = false;
            if (isCreate)
            {
                result = studentRepository.AddNewStudent(student);
            }
            else
            {
                result = studentRepository.UpdateStudent(student);
            }
            if (result)
            {
                Success();
            }
            else
            {
                Error();
            }
            close();
        }
        public void OnSubmitFail()
        {
            Error();
        }
        private void Error()
        {
            message.Error("Fail");
        }
        private void Success()
        {
            message.Success("Successfull");
        }
        public void DeleteStudent(StudentViewDTO studentViewDTO)
        {
            student = studentRepository.GetStudentById(studentViewDTO.Id);
            studentRepository.DeleteStudent(student);
            UpdateListStudents();
        }
    }
}
