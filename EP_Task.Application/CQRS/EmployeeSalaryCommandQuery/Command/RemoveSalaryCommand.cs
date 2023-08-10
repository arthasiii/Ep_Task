using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Command
{
    public class RemoveSalaryCommand:IRequest<RemoveSalaryCommandResponse>
    {
        public int EmployeeId { get; set; }

        public string salaryDate { get; set; }

    }
    public  class RemoveSalaryCommandResponse
    {
        public string message { get; set; }
        public string resultcode { get; set; }

    }
}
