using EP_Task.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Queries
{
    public class GetsalaryQuery:IRequest<GetsalaryQueryResponse>
    {
        public int IdEmpolyee { get; set; }
        public string Datetime { get; set; }
    }

    public class GetsalaryQueryResponse

    {
        public Employee? employee { get; set; }

        public string message { get; set; }
    }
}
