using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Application.Dto
{
    public class SalaryDto
    {
        public double BasicSalary { get; set; }

        public double Allowance { get; set; }

        public double Transportation { get; set; }

        public DateTime DateSallary { get; set; }

        public double Income { get; set; }
        public int EmployeeId { get; set; }
    }
}
