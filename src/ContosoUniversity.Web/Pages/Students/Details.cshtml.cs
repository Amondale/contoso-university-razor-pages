using System;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.Application.ViewModels;

namespace ContosoUniversity.Web.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public DetailsModel(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [BindProperty]
        public StudentViewModel Student { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = _mapper.Map<StudentViewModel>(await _repository.GetStudentAsync(id));

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
