using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ContosoUniversity.Web.Pages.Courses
{
    public class DepartmentNamePageModel : PageModel
    {
        protected readonly IDepartmentRepository DepartmentRepository;

        public DepartmentNamePageModel(IDepartmentRepository repository)
        {
            DepartmentRepository = repository;
        }

        public SelectList DepartmentSelectList { get; set; }

        public async void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            DepartmentSelectList = new SelectList(await DepartmentRepository.GetDepartmentsAsync(),
                "Id", "DepartmentName", selectedDepartment);
        }
    }
}