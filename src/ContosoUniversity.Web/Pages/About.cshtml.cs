using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using ContosoUniversity.Application.ViewModels;
using ContosoUniversity.Infrastructure.Interfaces;

namespace ContosoUniversity.Web.Pages
{
    public class AboutModel : PageModel
    {
        private readonly IEnrollmentRepository _repository;

        public AboutModel(IEnrollmentRepository repository)
        {
            _repository = repository;
        }

        public IList<EnrollmentTotalsViewModel> StudentTotals { get; set; }

        public async Task OnGetAsync()
        {
            StudentTotals = await _repository.GetEnrollmentTotalsAsync();
        }

    }
}
