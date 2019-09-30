using System;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.Application.ViewModels;

namespace ContosoUniversity.Web.Pages.Instructors
{
    public class DetailsModel : PageModel
    {
        private readonly IInstructorRepository _repository;
        private readonly IMapper _mapper;

        public DetailsModel(IInstructorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [BindProperty]
        public InstructorViewModel Instructor { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Instructor = _mapper.Map<InstructorViewModel>(await _repository.GetInstructorWithChildrenAsync(id));

            if (Instructor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
