using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExclusiveRazorpages.Services;
using ExclusiveRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExclusiveRazorpages.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;

        public EditModel(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        // This is the property the display template will use to
        // display existing Employee data

      
        public Employee Employee { get; private set; }

        // Populate Employee property
        public IActionResult OnGet(int id)
        {
            Employee = employeeRepository.GetEmployee(id);

            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(Employee employee)
        {
            Employee = employeeRepository.Update(employee);
            return RedirectToPage("Index");
        }
    }
}
