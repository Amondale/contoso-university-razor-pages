using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly IDepartmentRepository _repository;

        public IndexModel(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public IList<Department> Department { get;set; }

        public async Task OnGetAsync()
        {
            Department = await _repository.GetDepartmentsAsync();
        }
    }
}
