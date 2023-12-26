using AntDesign;
using BlazorWebAppRGPC.Model;
using BlazorWebAppRGPC.Model.DTO;
using BlazorWebAppRGPC.Model.Mapper;
using BlazorWebAppRGPC.Service;
using BlazorWebAppRGPC.Service.IService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Share;
using System.Drawing.Printing;

namespace BlazorWebAppRGPC.Pages
{
    public partial class ListClass
    {
        [Inject] IClassService classService { get; set; }
        [Inject] ITeacherService teacherService { get; set; }
        [Inject] ClasssMapper classMapper { get; set; }
        [Inject] IMessageService message {  get; set; }


        public List<ClassViewDTO> listClass = new List<ClassViewDTO>();
        public List<ClassViewDTO> listClassPage = new List<ClassViewDTO>();
        public List<Teacher> listTeacher = new List<Teacher>();
        public ClassDTO classDTO = new ClassDTO();
        public Class _class = new Class();
        public ClassViewDTO classSearch = new ClassViewDTO();
        private int pageNumber = 1;
        private int pageSize = 5;
        private int totalCount = 0;

        public bool isCreate = true;
        public bool isPopupVisible = false;
        protected override async Task OnInitializedAsync()
        {
            listTeacher = teacherService.GetAllTeachers();
            await loadData();
        }
        private async Task loadData()
        {
            var result = classService.GetDataPage(pageNumber, pageSize, classSearch);
            listClassPage = result.ClassViews;
            totalCount = result.Total;
            StateHasChanged();
        }
        public async Task OnPaging()
        {
            await loadData();
        }
        private async void OnValidSubmit()
        {
            pageNumber = 1;
            await loadData();
        }
        private void OnInvalidSubmit()
        {
            classSearch = new ClassViewDTO();
        }
        private void ShowPopupClass(ClassViewDTO classViewDTO)
        {
            isPopupVisible = true;
            classDTO = new ClassDTO();
            if (classViewDTO != null)
            {
                isCreate = false;
                classDTO.Id = classViewDTO.Id;
                classDTO.Name = classViewDTO.Name;
                classDTO.SubjectName = classViewDTO.SubjectName;
                classDTO.TeacherId = classViewDTO.TeacherId;
            }
            else
            {
                isCreate = true;
            }
        }
        private void OnSubmitSuccess()
        {
            BooleanGrpc check;
            if (isCreate)
            {
                check = classService.AddNewClass(classDTO);
            }
            else
            {
                check = classService.UpdateClass(classDTO);
            }
            if (check.result)
            {
                Success(check.mess);
            }
            else
            {
                Error(check.mess);
            }
            close();
        }
        public void OnSubmitFail()
        {
            Error("Fail");
        }
        private void Error(string mes)
        {
            message.Error(mes,5);
        }
        private void Success(string mes)
        {
            message.Success(mes,3);
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
            classSearch = new ClassViewDTO();

            UpdateListClass();
        }
        private async void UpdateListClass()
        {
            pageNumber = 1;
            await loadData();
        }
        public void DeleteClass(ClassViewDTO classViewDTO)
        {
            var check = classService.DeleteClass(classViewDTO);
            if (check.result)
            {
                Success(check.mess);
            }
            else
            {
                Error(check.mess);
            }
            UpdateListClass();
        }
    }
}
