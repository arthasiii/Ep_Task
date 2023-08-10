using EP_Task.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Queries
{
    public class GetAllEmployeeQuery:IRequest<GetEmployeeQueryResponse>
    {
    }

    public class GetEmployeeQueryResponse
    {
        public List<EmployeeDto> Employeelist { get; set; }
    }
}
