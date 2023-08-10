using AutoMapper;
using EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Queries;
using EP_Task.Application.Dto;
using EP_Task.Domain.Entities;
using EP_Task.Domain.IRepository;
using EP_Task.Infrastructure.Infrastructurecontext;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Handler
{
    public class GetAllsalaryQueryHandler : IRequestHandler<GetAllsalaryQuery, GetAllsalaryQueryResponse>

    {
        private readonly EPTaskDbcontext _dbcontext;
        private readonly IEmployeeSalaryRepository _repository;
      

        public GetAllsalaryQueryHandler(EPTaskDbcontext dbcontext, IEmployeeSalaryRepository repository)
        {
            _dbcontext = dbcontext;
            _repository = repository;
         
        }
        public async Task<GetAllsalaryQueryResponse> Handle(GetAllsalaryQuery request, CancellationToken cancellationToken)
        {
            var employeeList = await _repository.GetAllSalarryAsync(request.IdEmpolyee, request.StartTime, request.EndTime);
            GetAllsalaryQueryResponse response = new GetAllsalaryQueryResponse();
          var  employee = _dbcontext.Employees.SingleOrDefault(a => a.Id== request.IdEmpolyee);
            employee.Salaries = employeeList;
            response.employee= employee;
            
            return response;


        }
    }

}
