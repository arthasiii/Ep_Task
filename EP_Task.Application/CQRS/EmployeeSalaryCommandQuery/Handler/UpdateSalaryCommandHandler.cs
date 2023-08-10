using Azure;
using Azure.Core;
using EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Command;
using EP_Task.Application.CQRS.Notification;
using EP_Task.Domain.Entities;
using EP_Task.Infrastructure.Infrastructurecontext;
using EP_Task.Infrastructure.Utility;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OvetimePolicies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Handler
{
    public class UpdateSalaryCommandHandler : IRequestHandler<UpdateSalaryCommand, UpdateSalaryCommandResponse>
    {
        private readonly EPTaskDbcontext _dBContext; // Replace YourDatabaseContext with your actual database context
        private readonly IMediator _mediator;
        public UpdateSalaryCommandHandler(EPTaskDbcontext dBContext, IMediator mediator)
        {
            _dBContext = dBContext;
            _mediator = mediator;
        }

        public async Task<UpdateSalaryCommandResponse> Handle(UpdateSalaryCommand request, CancellationToken cancellationToken)
        {
            var emplooyee = await _dBContext.Employees.Where(a => a.FirstName == request.Data.FirstName && a.LastName == request.Data.LastName).SingleOrDefaultAsync();

            if (emplooyee != null)
            {
                DateTime checktime = DateConvertor.SpecialShamsiToMilad(request.Data.DateSalary);
                var salary = await _dBContext.Salaries.Where(a => a.EmployeeId == emplooyee.Id
                && a.DateSallary == checktime).FirstOrDefaultAsync();

                if (salary != null)
                {
                    salary.BasicSalary=request.Data.BasicSalary;
                    salary.Allowance=  request.Data.Allowance;
                    salary.Transportation= request.Data.Transportation;
                    double incomefirst = request.Data.BasicSalary + request.Data.Allowance +
                       request.Data.Transportation;

                    OverTimeCalculator OT = new OverTimeCalculator();
                    double income = (double)OT.GetType().GetMethod(request.OverTimeCalculator).Invoke(OT, new object[] { incomefirst });

                    salary.Income = income;

                    await _dBContext.SaveChangesAsync();
                    var response = new UpdateSalaryCommandResponse
                    {
                        IdSalay = salary.Id,
                        message = "با موفقیت تغییر یافت",
                        ResultCode = HttpStatusCode.BadRequest.ToString()

                    };
                    return response;
                }
                else
                {
                    var response = new UpdateSalaryCommandResponse
                    {
                        IdSalay = 0,
                        message = "اطلاعات زمانی جهت تغییر دیتا اشتباه می باشد",
                        ResultCode = HttpStatusCode.BadRequest.ToString()

                    };
                    return response;
                }

                
           
            }
            else
            {
                var response = new UpdateSalaryCommandResponse
                {
                    IdSalay = 0,
                    message = "کاربر مورد نظر  جهت به روز رسانی در سیستم یافت نشد",
                    ResultCode = HttpStatusCode.BadRequest.ToString()

                };
                return response;
            }



        }
    }
}
