using EP_Task.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Command
{
    public class UpdateSalaryCommand:IRequest<UpdateSalaryCommandResponse>
    {
        public CustomEmployeeSalaryDto Data { get; set; }
        public string OverTimeCalculator { get; set; }
    }
    public class UpdateSalaryCommandResponse
    {
        public int IdSalay { get; set; }
        public string? message { get; set; }
        public string? ResultCode { get; set; }


    }
}
