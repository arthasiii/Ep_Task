using EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Command;
using EP_Task.Application.Dto;
using EP_Task.Infrastructure.Infrastructurecontext;
using MediatR;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EP_Task.Domain.Entities;
using EP_Task.Application.CQRS.Notification;
using OvetimePolicies;

namespace EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Handler
{
    public class AddEmployeeSalaryCommandHandler : IRequestHandler<AddEmployeeSalaryCommand,AddEmployeeSalaryCommandResponse>
    {
        private readonly EPTaskDbcontext _dBContext; // Replace YourDatabaseContext with your actual database context
        private readonly IMediator _mediator;
        public AddEmployeeSalaryCommandHandler(EPTaskDbcontext dBContext, IMediator mediator)
        {
            _dBContext = dBContext;
            _mediator = mediator;
        }

    

        public async Task<AddEmployeeSalaryCommandResponse> Handle(AddEmployeeSalaryCommand request, CancellationToken cancellationToken)
        {
      
            var emplooyee = await _dBContext.Employees.Where(a => a.FirstName == request.Data.FirstName && a.LastName == request.Data.LastName).SingleOrDefaultAsync();
            if (emplooyee == null)
            {
                Employee Addemployee = new Employee()
                {
                    FirstName = request.Data.FirstName,
                    LastName = request.Data.LastName,
                    EmployeId = Guid.NewGuid().ToString(),
                };
               await _dBContext.Employees.AddAsync(Addemployee);
                await _dBContext.SaveChangesAsync();
                var addsalarynotification = new AddSallaryNotification
                {
                    OverTimeCalc=request.OverTimeCalculator,
                    BasicSalary = request.Data.BasicSalary,
                    Allowance = request.Data.Allowance,
                    Transportation = request.Data.Transportation,
                    EmployeeId = Addemployee.Id,
                    DateSalary = request.Data.DateSalary,
                };
                await _mediator.Publish(addsalarynotification);
                await _dBContext.SaveChangesAsync();

                var response = new AddEmployeeSalaryCommandResponse
                {
                    IdEmployee = Addemployee.Id
                };
                return response;
            }
            else
            {

                var addsalarynotification = new AddSallaryNotification
                {
                    OverTimeCalc = request.OverTimeCalculator,
                    BasicSalary = request.Data.BasicSalary,
                    Allowance = request.Data.Allowance,
                    Transportation = request.Data.Transportation,
                    EmployeeId = emplooyee.Id,
                    DateSalary = request.Data.DateSalary,
                };
            await _mediator.Publish(addsalarynotification);

                var response = new AddEmployeeSalaryCommandResponse
                {
                    IdEmployee = emplooyee.Id
                };
                return response;
            }



        }

    }
}
