using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Application.Dto
{
    public class CustomEmployeeSalaryDto
    {
        public  string? FirstName { get; set; }
        public  string? LastName { get; set; }
        public double BasicSalary { get; set; }
        public double Allowance { get; set; }
        public double Transportation { get; set; }
        public string?  DateSalary{ get; set; }
    }
}
