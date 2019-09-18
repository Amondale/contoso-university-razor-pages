using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IStudentRepository _repository;

        public CreateModel(IStudentRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyStudent = new Student();

            if (await TryUpdateModelAsync<Student>(emptyStudent, "student", s => s.FirstName, s => s.LastName, s => s.EnrollmentDate))
            {
                await _repository.AddAsync(emptyStudent);
                return RedirectToPage("./Index");
            }

            return null;
        }
    }
}