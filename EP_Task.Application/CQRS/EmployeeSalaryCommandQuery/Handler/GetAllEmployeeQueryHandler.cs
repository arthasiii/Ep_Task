using AutoMapper;
using Azure;
using EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Queries;
using EP_Task.Application.Dto;
using EP_Task.Domain.Entities;
using EP_Task.Domain.IRepository;
using EP_Task.Infrastructure.Infrastructurecontext;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Handler
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, GetEmployeeQueryResponse>
    {
        private readonly EPTaskDbcontext _dbcontext;
        private readonly IEmployeeSalaryRepository _repository;
        private readonly IMapper _mapper;

        public GetAllEmployeeQueryHandler(EPTaskDbcontext dbcontext,IEmployeeSalaryRepository repository,IMapper mapper)
        {
            _dbcontext = dbcontext;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetEmployeeQueryResponse> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {

            var employeeList = await _repository.GetAllEmployeeAsync();
            GetEmployeeQueryResponse response = new GetEmployeeQueryResponse();
            response.Employeelist = _mapper.Map<List<EmployeeDto>>(employeeList);

            return response;



        }
    }
}
