using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Data;
using RazorPagesDemo.Models.Domain;

namespace RazorPagesDemo.Pages.Employees
{
    public class ListModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;

        public List<Employee> Employees { get; set; }

        public ListModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            Employees = dbContext.Employees.ToList();
        }
    }
}
