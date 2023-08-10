using EP_Task.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Command
{
    public class AddEmployeeSalaryCommand:IRequest<AddEmployeeSalaryCommandResponse>
    {
        public CustomEmployeeSalaryDto Data { get; set; }
        public string OverTimeCalculator { get; set; }

    }
    public class AddEmployeeSalaryCommandResponse
    {
        public int IdEmployee { get; set; }

    }

}
