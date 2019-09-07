using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ICourseRepository _courseRepository;
        
        public IndexModel(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IList<Course> Course { get;set; }

        public async Task OnGetAsync()
        {
            Course = await _courseRepository.GetCoursesAsync();
        }
    }
}
