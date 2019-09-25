using System;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.Application.ViewModels;
using ContosoUniversity.Common.Extensions;

namespace ContosoUniversity.Web.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public CreateModel(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            Student = _mapper.Map<StudentViewModel>(new Student());
            Student.EnrollmentDate = DateTime.Today.TruncateMinutesAndSeconds();
            return Page();
        }

        [BindProperty]
        public StudentViewModel Student { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyStudent = new Student();

            if (await TryUpdateModelAsync<Student>(
                emptyStudent, 
                "student", 
                s => s.Prefix
                , s => s.FirstName
                , s => s.MiddleName
                , s => s.LastName
                , s => s.Prefix
                , s => s.EnrollmentDate
                , s => s.DateOfBirth))
            {
                await _repository.AddAsync(emptyStudent);
                return RedirectToPage("./Index");
            }

            return null;
        }
    }
}