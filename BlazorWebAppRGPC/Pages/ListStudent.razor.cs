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

namespace BlazorWebAppRGPC.Pages
{
    public partial class ListStudent
    {
        private List<StudentViewDTO> listStudentViewDTO = new List<StudentViewDTO>();
        private List<Class> listClass = new List<Class>();
        public StudentSearch studentSearch = new StudentSearch();
        public StudentDTO studentAdd = new StudentDTO();
        [Inject] StudentMapper studentMapper { get; set; }
        [Inject] IClassRepository classRepository { get; set; }

        private int pageNumber = 1;
        private int pageSize = 2;
        private int totalCount = 0;
        private PageView<Student> pageItems = new PageView<Student>();
        ITable table;
        private EditForm formSearch;
        private bool isPopupVisible = false;
        public bool isCreate = true;

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
        private void ShowPopup()
        {
            isPopupVisible = true;
        }
        private void HidePopup()
        {
            isPopupVisible = false;
        }
        private void OnAddUserSubmit()
        {
            
        }
    }
}
