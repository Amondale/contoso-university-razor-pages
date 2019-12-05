using AutoMapper;
using ContosoUniversity.Application.ViewModels;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public DetailsModel(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [BindProperty]
        public DepartmentViewModel Department { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = _mapper.Map<DepartmentViewModel>(await _repository.GetDepartmentAsync(id));

            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
