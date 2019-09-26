using AutoMapper;
using ContosoUniversity.Application.ViewModels;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Courses
{
    public class CreateModel : DepartmentNamePageModel
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        
        [BindProperty]
        public CourseViewModel Course { get; set; }

        public CreateModel(IDepartmentRepository departmentRepository, ICourseRepository courseRepository, IMapper mapper) : base(departmentRepository)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            Course = _mapper.Map<CourseViewModel>(new Course());
            PopulateDepartmentsDropDownList(null);
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return OnGet();
            }

            var emptyCourse = new Course();

            if (await TryUpdateModelAsync<Course>(
                emptyCourse,
                "course",
                s => s.Id, s => s.DepartmentId, s => s.Title, s => s.Credits))
            {

                await _courseRepository.AddAsync(emptyCourse);

                return RedirectToPage("./Index");
            }
            
            return OnGet();
        }
    }
}