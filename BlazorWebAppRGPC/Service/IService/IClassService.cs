using BlazorWebAppRGPC.Model;
using BlazorWebAppRGPC.Model.DTO;

namespace BlazorWebAppRGPC.Service.IService
{
    public interface IClassService
    {
        public List<ClassViewDTO> GetAllClasss();

        public void AddNewClass(ClassDTO classNew);

        public void UpdateClass(Class classUpdate);

        public void DeleteClass(Class classDelete);

        public List<Class> SortData();

        public Class GetClassById(int id);
        public int GetIDNewClass();
    }
}
