using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly IDepartmentRepository _repository;

        public DetailsModel(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await _repository.GetDepartmentAsync(id);

            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
