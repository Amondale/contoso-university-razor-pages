using AutoMapper;
using ContosoUniversity.Application.ViewModels;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using ContosoUniversity.Core.Entities;

namespace ContosoUniversity.Web.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper;

        public CreateModel(IDepartmentRepository departmentRepository, IInstructorRepository instructorRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }

        public SelectList DepartmentChairSelectList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Department = _mapper.Map<DepartmentViewModel>(new Department());

            DepartmentChairSelectList = new SelectList(await _instructorRepository.GetInstructorsAsync(), "Id", "FullName");

            return Page();
        }

        [BindProperty]
        public DepartmentViewModel Department { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyDepartment = new Department();

            if (await TryUpdateModelAsync<Department>(
                emptyDepartment,
                "department",
                 d => d.Id, 
                                    d => d.DepartmentName,
                                    d => d.Budget,
                                    d => d.FoundedDate,
                                    d => d.DepartmentChairId
            ))
            { 
                await _departmentRepository.AddAsync(emptyDepartment);
            
                return RedirectToPage("./Index");
            }

            return await OnGet();
        }

    }
}