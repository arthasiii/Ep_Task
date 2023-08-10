using EP_Task.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Queries
{
    public class GetAllsalaryQuery:IRequest<GetAllsalaryQueryResponse>
    {
        public int IdEmpolyee { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
    public class GetAllsalaryQueryResponse
    {
        public Employee employee { get; set; }

    }
}
