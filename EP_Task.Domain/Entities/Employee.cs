using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? EmployeId { get; set; }
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public ICollection<Salary> Salaries { get; set;}
    }
}
