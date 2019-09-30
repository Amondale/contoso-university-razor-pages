using AutoMapper;
using ContosoUniversity.Application.ViewModels;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public IndexModel(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IList<DepartmentViewModel> Department { get;set; }

        public async Task OnGetAsync()
        {
            Department = _mapper.Map<List<DepartmentViewModel>>(await _repository.GetDepartmentsAsync());
        }
    }
}
