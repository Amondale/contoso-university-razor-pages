using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IInstructorRepository _instructorRepository;

        public CreateModel(IDepartmentRepository departmentRepository, IInstructorRepository instructorRepository)
        {
            _departmentRepository = departmentRepository;
            _instructorRepository = instructorRepository;
        }

        public SelectList InstructorNameSL { get; set; }
        public IActionResult OnGet()
        {
            InstructorNameSL = new SelectList(_instructorRepository.GetInstructors(), "ID", "FirstMidName");
            return Page();
        }

        [BindProperty]
        public Department Department { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _departmentRepository.AddAsync(Department);

            return RedirectToPage("./Index");
        }

    }
}