using AutoMapper;
using ContosoUniversity.Application.ViewModels;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Instructors
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public InstructorViewModel Instructor { get; set; }

        private readonly IInstructorRepository _instructorRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public EditModel(IInstructorRepository instructorRepository, ICourseRepository courseRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            Instructor = _mapper.Map<InstructorViewModel>(await _instructorRepository.GetInstructorWithChildrenAsync(id));

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
                i => i.Prefix,
                i => i.FirstName,
                i => i.MiddleName,
                i => i.LastName,
                i => i.Suffix,
                i => i.OfficeLocation,
                i => i.DateOfBirth,
                i => i.HireDate))
            {
                await _instructorRepository.UpdateAsync(instructorToUpdate);

                return RedirectToPage("./Index");
            }
            
            return Page();
        }
    }
}
