using BlazorWebAppRGPC.Model;
using BlazorWebAppRGPC.Model.DTO;
using BlazorWebAppRGPC.Model.Mapper;
using BlazorWebAppRGPC.Service;
using BlazorWebAppRGPC.Service.IService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Share;

namespace BlazorWebAppRGPC.Pages
{
    public partial class ListClass
    {
        [Inject] IClassService classService { get; set; }
        [Inject] ITeacherService teacherService { get; set; }
        [Inject] ClassMapper classMapper { get; set; }


        public List<ClassViewDTO> listClass = new List<ClassViewDTO>();
        public List<Teacher> listTeacher = new List<Teacher>();
        public ClassDTO classDTO = new ClassDTO();
        public Class _class = new Class();

        public bool isCreate = true;
        public bool isPopupVisible = false;
        protected override async Task OnInitializedAsync()
        {
            await loadData();
        }
        private async Task loadData()
        {
            listClass = classService.GetAllClasss();
            //classObject = new ClassDTO();
            StateHasChanged();

        }
        private void ShowPopupClass(ClassViewDTO classViewDTO)
        {
            isPopupVisible = true;
            listTeacher = teacherService.GetAllTeachers();

            if (classViewDTO != null)
            {
                isCreate = false;
                _class = classService.GetClassById(classViewDTO.Id);
            }
            else
            {
                isCreate = true;
            }
            classDTO = classMapper.ClassToClassDTO(_class, isCreate);
        }
        private void OnSubmitSuccess()
        {
            bool result = false;
            if (isCreate)
            {
                 classService.AddNewClass(classDTO);
            }
            else
            {
                //result = studentRepository.UpdateStudent(student);
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
        public void close()
        {
            Clear();
            isPopupVisible = false;
        }
        public void Clear()
        {
            classDTO = new ClassDTO();
            isCreate = true;
            //studentSearch = new StudentSearch();

            UpdateListClass();
        }
        private async void UpdateListClass()
        {
            //pageNumber = 1;
            await loadData();
        }
    }
}
