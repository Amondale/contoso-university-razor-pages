using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly ICourseRepository _courseRepository;

        public DeleteModel(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _courseRepository.GetCourseAsync(id);

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _courseRepository.GetCourseAsync(id);

            if (Course != null)
            {
                await _courseRepository.DeleteAsync(Course);
            }

            return RedirectToPage("./Index");
        }
    }
}
