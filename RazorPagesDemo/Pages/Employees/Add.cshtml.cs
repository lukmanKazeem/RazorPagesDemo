using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Data;
using RazorPagesDemo.Models.Domain;
using RazorPagesDemo.Models.ViewModels;

namespace RazorPagesDemo.Pages.Employees
{
    public class AddModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;

        public AddModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public AddEmployeeViewModel AddEmployeeRequest { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            // Cionvert ViewMOdel into DamainModel
            var employeeDomainModel = new Employee
            {
                Name = AddEmployeeRequest.Name,
                Email = AddEmployeeRequest.Email,
                Salary = AddEmployeeRequest.Salary,
                Department = AddEmployeeRequest.Department,
                DateOfBirth = AddEmployeeRequest.DateOfBirth,
            };

            dbContext.Employees.Add(employeeDomainModel);
            dbContext.SaveChanges();

            ViewData["Message"] = "Employee crearted sucessfully";
        }
    }
}
