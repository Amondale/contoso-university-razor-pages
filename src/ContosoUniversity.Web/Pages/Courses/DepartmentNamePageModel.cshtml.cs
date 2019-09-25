using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ContosoUniversity.Web.Pages.Courses
{
    public class DepartmentNamePageModel : PageModel
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentNamePageModel(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public SelectList DepartmentNameSl { get; set; }

        public void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            DepartmentNameSl = new SelectList(_repository.GetDepartments(),
                "DepartmentId", "DepartmentName", selectedDepartment);
        }
    }
}