using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly ICourseRepository _repository;

        public DetailsModel(ICourseRepository repository)
        {
            _repository = repository;
        }

        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _repository.GetCourseAsync(id);

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
