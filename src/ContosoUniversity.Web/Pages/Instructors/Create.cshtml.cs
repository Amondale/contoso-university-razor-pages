using AutoMapper;
using ContosoUniversity.Application.ViewModels;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Instructors
{
    public class Create : PageModel
    {
        [BindProperty]
        public InstructorViewModel Instructor { get; set; }

        private readonly IInstructorRepository _instructorRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public Create(IInstructorRepository instructorRepository, ICourseRepository courseRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            var emptyInstructor = new Instructor();
            Instructor = _mapper.Map<InstructorViewModel>(emptyInstructor);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var newInstructor = new Instructor();

            if (await TryUpdateModelAsync<Instructor>(
                newInstructor,
                "Instructor",
                i=> i.Prefix,
                                    i => i.FirstName,
                                    i => i.MiddleName,
                                    i => i.LastName,
                                    i => i.Suffix,
                                    i => i.OfficeLocation,
                                    i => i.DateOfBirth,
                                    i => i.HireDate))
            {
                await _instructorRepository.AddAsync(newInstructor);

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}