using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Domain.Entities
{
    public class Salary
    {
        public int Id { get; set; }
        public double BasicSalary { get; set; }

        public double Allowance { get; set; }

        public double Transportation { get; set; }

        public DateTime DateSallary { get; set; }

        public double Income { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
