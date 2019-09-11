using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly IStudentRepository _repository;

        public DetailsModel(IStudentRepository repository)
        {
            _repository = repository;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _repository.GetStudentAsync(id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
