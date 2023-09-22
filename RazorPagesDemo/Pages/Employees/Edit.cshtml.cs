using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Data;
using RazorPagesDemo.Models.Domain;
using RazorPagesDemo.Models.ViewModels;

namespace RazorPagesDemo.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;

        [BindProperty]
        public EditEmployeeViewModel EditEmployeeViewModel { get; set; }

        public EditModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee != null)
            {
                // Convert Domain Model to ViewMOdel
                EditEmployeeViewModel = new EditEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    Department = employee.Department,
                    DateOfBirth = employee.DateOfBirth,
                };
            }
        }

        public void OnPostUpdate()
        {
            if (EditEmployeeViewModel != null)
            {
                var existingEmployee = dbContext.Employees.Find(EditEmployeeViewModel.Id);

                if (existingEmployee != null)
                {
                    // Convert ViewModel to DomainModel
                    existingEmployee.Id = EditEmployeeViewModel.Id;
                    existingEmployee.Name = EditEmployeeViewModel.Name;
                    existingEmployee.Email = EditEmployeeViewModel.Email;
                    existingEmployee.Salary = EditEmployeeViewModel.Salary;
                    existingEmployee.DateOfBirth = EditEmployeeViewModel.DateOfBirth;
                    existingEmployee.Department = EditEmployeeViewModel.Department;

                    dbContext.SaveChanges();

                    ViewData["Message"] = "Employee updated sucessfully";
                }
            }
        }

        public IActionResult OnPostDelete()
        {
            var existingEmployee = dbContext.Employees.Find(EditEmployeeViewModel.Id);

            if (existingEmployee != null)
            {
                dbContext.Employees.Remove(existingEmployee);
                dbContext.SaveChanges();

                return RedirectToPage("/Employees/List");
            }

            return Page();
        }
    }
}
