using EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Command;
using EP_Task.Infrastructure.Infrastructurecontext;
using EP_Task.Infrastructure.Utility;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Handler
{
    public class RemoveSalaryCommandHandler : IRequestHandler<RemoveSalaryCommand, RemoveSalaryCommandResponse>
    {
        private EPTaskDbcontext _dbcontext;
        public RemoveSalaryCommandHandler(EPTaskDbcontext dbcontext)
        {

            _dbcontext = dbcontext;
        }
        public async Task<RemoveSalaryCommandResponse> Handle(RemoveSalaryCommand request, CancellationToken cancellationToken)
        {

            DateTime checktime = DateConvertor.SpecialShamsiToMilad(request.salaryDate);
            var salaryfind=await _dbcontext.Salaries.Where(a=>a.EmployeeId==request.EmployeeId && a.DateSallary== checktime).FirstOrDefaultAsync();

        if(salaryfind!=null) {
                _dbcontext.Salaries.Remove(salaryfind);
              await  _dbcontext.SaveChangesAsync();
                var response = new RemoveSalaryCommandResponse();
                response.message = "با موفقیت حذف شد";
                response.resultcode = HttpStatusCode.OK.ToString();
                return response;
            }
            else
            {

                var response = new RemoveSalaryCommandResponse();
                response.message = "اطلاعات مورد نظر یافت نشد";
                response.resultcode = HttpStatusCode.NotFound.ToString();
                return response;

            }

          

        }
    }
}
