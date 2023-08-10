using EP_Task.Application.Dto;
using EP_Task.Domain.Entities;
using EP_Task.Domain.Entities.Security;
using EP_Task.Infrastructure.Infrastructurecontext;
using EP_Task.Infrastructure.Utility;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OvetimePolicies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EP_Task.Application.CQRS.Notification
{
    public class AddSallaryNotification : INotification
    {
        public double BasicSalary { get; set; }

        public double Allowance { get; set; }

        public double Transportation { get; set; }

        public string DateSalary { get; set; }

        public string OverTimeCalc { get; set; }

        public int EmployeeId { get; set; }

    }

    public class AddSallaryNotificationHandler : INotificationHandler<AddSallaryNotification>
    {
        private readonly EPTaskDbcontext _dBContext;
        delegate double DgOverTimeCalculator(double d);

        public AddSallaryNotificationHandler(EPTaskDbcontext dBContext)
        {
            _dBContext = dBContext;

        }
        public async Task Handle(AddSallaryNotification notification, CancellationToken cancellationToken)
        {
            double incomefirst = notification.BasicSalary + notification.Allowance +
             notification.Transportation;
            OverTimeCalculator OT = new OverTimeCalculator();
            double income= (double)OT.GetType().GetMethod(notification.OverTimeCalc).Invoke(OT,new object[] { incomefirst });

            

            DateTime salarydate= DateConvertor.SpecialShamsiToMilad(notification.DateSalary);
            Salary Addsalary = new Salary()
            {
                BasicSalary = notification.BasicSalary,
                Allowance = notification.Allowance,
                Transportation = notification.Transportation,
                EmployeeId = notification.EmployeeId,
                Income = income,
                DateSallary = salarydate,
            };
            await _dBContext.Salaries.AddAsync(Addsalary);
            await _dBContext.SaveChangesAsync();
        }
    }
}
