using BlazorWebAppRGPC.Model;
using BlazorWebAppRGPC.Model.DTO;
using BlazorWebAppRGPC.Model.Mapper;
using BlazorWebAppRGPC.Service.IService;
using Microsoft.AspNetCore.Components;
using Share;

namespace BlazorWebAppRGPC.Pages
{
    public partial class ListStudent
    {
        [Inject] IStudentService studentService {  get; set; }
        public List<Student> listStudent { get; set; }

        public StudentDTO studentObject = new StudentDTO();

        private StudentMapper studentMapper = new StudentMapper();
        protected override async Task OnInitializedAsync()
        {
            await loadDataAsync();
        }
        private async Task loadDataAsync()
        {
            listStudent = studentRepository.GetAllStudents();
            StateHasChanged();
        }
    }
}
