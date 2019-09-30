using ContosoUniversity.Application.ViewModels;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Instructors
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Instructor Instructor { get; set; }

        private readonly IInstructorRepository _instructorRepository;
        private readonly ICourseRepository _courseRepository;

        public EditModel(IInstructorRepository instructorRepository, ICourseRepository courseRepository)
        {
            _instructorRepository = instructorRepository;
            _courseRepository = courseRepository;
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            Instructor = await _instructorRepository.GetInstructorWithChildrenAsync(id);

            if (Instructor == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var instructorToUpdate = await _instructorRepository.GetInstructorWithChildrenAsync(id);

            if (await TryUpdateModelAsync<Instructor>(
                instructorToUpdate,
                "Instructor",
                i => i.FirstName, i => i.LastName,
                i => i.HireDate, i => i.OfficeLocation))
            {

                await _instructorRepository.UpdateAsync(instructorToUpdate);
                return RedirectToPage("./Index");
            }
            
            return Page();
        }
    }
}
