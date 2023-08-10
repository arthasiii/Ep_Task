using EP_Task.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Application.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string EmployeId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
