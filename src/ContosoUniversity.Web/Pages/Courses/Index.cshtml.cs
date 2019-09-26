using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.Application.ViewModels;

namespace ContosoUniversity.Web.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public IndexModel(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public IList<CourseViewModel> Course { get;set; }

        public async Task OnGetAsync()
        {
            Course = _mapper.Map<List<CourseViewModel>>(await _courseRepository.GetCoursesAsync());
        }
    }
}
