using System;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Instructors
{
    public class DetailsModel : PageModel
    {
        private readonly IInstructorRepository _repository;

        public DetailsModel(IInstructorRepository repository)
        {
            _repository = repository;
        }

        public Instructor Instructor { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Instructor = await _repository.GetInstructorWithChildrenAsync(id);

            if (Instructor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
