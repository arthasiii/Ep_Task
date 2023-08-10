using EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Queries;
using EP_Task.Domain.Entities;
using EP_Task.Domain.IRepository;
using EP_Task.Infrastructure.Infrastructurecontext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Handler
{
    public class GetsalaryQueryHandler : IRequestHandler<GetsalaryQuery, GetsalaryQueryResponse>
    {

        private readonly EPTaskDbcontext _dbcontext;
        private readonly IEmployeeSalaryRepository _repository;


        public GetsalaryQueryHandler(EPTaskDbcontext dbcontext, IEmployeeSalaryRepository repository)
        {
            _dbcontext = dbcontext;
            _repository = repository;

        }
        public async Task<GetsalaryQueryResponse> Handle(GetsalaryQuery request, CancellationToken cancellationToken)
        {
            var salary = await _repository.GetEmployeeSalary(request.IdEmpolyee, request.Datetime);
            GetsalaryQueryResponse response = new GetsalaryQueryResponse();
            if (salary == null)
            {
                response.message = " اطلاعات یک ماه یک فرد با تاریخ تطابق ندارد";
                return response;
            }
            List<Salary> sl = new List<Salary>();
            sl.Add(salary);

            var employee = _dbcontext.Employees.SingleOrDefault(a => a.Id == request.IdEmpolyee);
            employee.Salaries= sl;
            response.employee = employee;

            return response;
        }
    }
}
