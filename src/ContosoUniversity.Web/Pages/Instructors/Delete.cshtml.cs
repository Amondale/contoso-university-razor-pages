using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Instructors
{
    public class DeleteModel : PageModel
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public DeleteModel(IInstructorRepository instructorRepository, IDepartmentRepository departmentRepository)
        {
            _instructorRepository = instructorRepository;
            _departmentRepository = departmentRepository;
        }

        [BindProperty]
        public Instructor Instructor { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Instructor = await _instructorRepository.GetInstructorWithChildrenAsync(id);

            if (Instructor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var instructor = await _instructorRepository.GetInstructorWithChildrenAsync(id);

            var departments = await _departmentRepository.GetDepartmentsFromInstructor(id);

            foreach (var d in departments)
            {
                d.InstructorID = null;
                await _departmentRepository.UpdateAsync(d);
            }

            await _instructorRepository.DeleteAsync(instructor);
            return RedirectToPage("./Index");
        }
    }
}
