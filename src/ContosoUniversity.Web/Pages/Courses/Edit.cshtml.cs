using System;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.Application.ViewModels;

namespace ContosoUniversity.Web.Pages.Courses
{
    public class EditModel : DepartmentNamePageModel
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public EditModel(IDepartmentRepository departmentRepository, ICourseRepository repository, IMapper mapper) : base(departmentRepository)
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

            PopulateDepartmentsDropDownList(Course.DepartmentId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (!ModelState.IsValid)
            {
                PopulateDepartmentsDropDownList(Course.DepartmentId);
                return Page();
            }

            var courseToUpdate = await _repository.GetCourseAsync(id);

            if (await TryUpdateModelAsync<Course>(
                courseToUpdate,
                "course",
                c => c.Credits, c => c.DepartmentId, c => c.Title))
            {
                await _repository.UpdateAsync(courseToUpdate);
                return RedirectToPage("./Index");
            }

            PopulateDepartmentsDropDownList(Course.DepartmentId);
            return Page();
        }


    }
}
