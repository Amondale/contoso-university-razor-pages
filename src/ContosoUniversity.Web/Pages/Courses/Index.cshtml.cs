using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Web.Data;
using ContosoUniversity.Web.Models;
using ContosoUniversity.Web.Models.SchoolViewModels;

namespace ContosoUniversity.Web.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Web.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity.Web.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; }

        //public IList<CourseViewModel> CourseVM { get; set; }

        public async Task OnGetAsync()
        {
            Course = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
