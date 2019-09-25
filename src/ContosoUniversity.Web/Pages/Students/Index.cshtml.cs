using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.Application.ViewModels;
using X.PagedList;

namespace ContosoUniversity.Web.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public IndexModel(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IPagedList<StudentViewModel> Students { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            var page = pageIndex ?? 1;
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            var tempStudents = await _repository.GetStudentsByFilter(searchString, sortOrder);
            Students = _mapper.Map<List<StudentViewModel>>(tempStudents).ToPagedList(page, 8);
        }
    }
}
