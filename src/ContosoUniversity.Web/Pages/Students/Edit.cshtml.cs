using System;
using System.Collections.Generic;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.Application.ViewModels;

namespace ContosoUniversity.Web.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public EditModel(IStudentRepository repository, IMapper mapper)
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var studentToUpdate = await _repository.GetStudentAsync(id);

            if (await TryUpdateModelAsync<Student>(
                studentToUpdate,
                "student",
                s=> s.Prefix
                , s => s.FirstName
                , s => s.MiddleName
                , s => s.LastName
                , s => s.Prefix
                , s => s.EnrollmentDate
                , s =>s.DateOfBirth
                ))
            {

                await _repository.UpdateAsync(studentToUpdate);

                return RedirectToPage("./Index");
            }

            return Page();
        }

    }
}
