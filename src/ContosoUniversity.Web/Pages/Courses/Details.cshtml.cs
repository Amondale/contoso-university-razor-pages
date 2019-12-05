using AutoMapper;
using ContosoUniversity.Application.ViewModels;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public DetailsModel(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [BindProperty]
        public CourseViewModel Course { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = _mapper.Map<CourseViewModel>(await _repository.GetCourseAsync(id));

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
