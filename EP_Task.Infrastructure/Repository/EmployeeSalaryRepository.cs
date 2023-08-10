using EP_Task.Domain.Entities;
using EP_Task.Domain.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using EP_Task.Infrastructure.Utility;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using EP_Task.Infrastructure.Infrastructurecontext;
using Microsoft.EntityFrameworkCore;

namespace EP_Task.Infrastructure.Repository
{
    public class EmployeeSalaryRepository : IEmployeeSalaryRepository
    {
        private IConfiguration _configuration;
        private EPTaskDbcontext _db;
        public EmployeeSalaryRepository(IConfiguration configuration, EPTaskDbcontext db)
        {

            _configuration = configuration;

            _db = db;
        }


        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            var connectionstring = _configuration.GetConnectionString("EPTaskDbcontextConnection");
            var query = "select * from Employees";

            using(IDbConnection connet=new SqlConnection(connectionstring))
            {
                var reult=await connet.QueryAsync<Employee>(query);
                return reult.ToList();
            }

        }




        public async Task<List<Salary>> GetAllSalarryAsync(int Id, string starttime, string endtime)
        {

            DateTime startdate = DateConvertor.SpecialShamsiToMilad(starttime);
            DateTime enddate = DateConvertor.SpecialShamsiToMilad(endtime);
            var connectionstring = _configuration.GetConnectionString("EPTaskDbcontextConnection");
            var query = @"select * from Salaries as sal where
                         sal.EmployeeId=@employeID and sal.DateSallary>=@datestart And
                          sal.DateSallary<=@dateEnd";
            var parameters = new{employeID = Id, datestart = startdate, dateEnd = enddate };
            //var parameterstartDate= new { datestart = startdate };
            //var parameterdateEnd = new { dateEnd= enddate };

            using (IDbConnection connet = new SqlConnection(connectionstring))
            {
                var result = await connet.QueryAsync<Salary>(query, parameters);

                return result.ToList();
            }

       

        }

        public async Task<Salary> GetEmployeeSalary(int Id, string datetime)
        {
            DateTime Datetime = DateConvertor.SpecialShamsiToMilad(datetime);
            var connectionstring = _configuration.GetConnectionString("EPTaskDbcontextConnection");
            var query = @"select * from Salaries as sal where
                         sal.EmployeeId=@employeID and sal.DateSallary=@datetimeset";
            var parameters = new { employeID = Id, datetimeset = Datetime };


            using (IDbConnection connet = new SqlConnection(connectionstring))
            {
                var result = await connet.QueryAsync<Salary>(query, parameters);

                return result.FirstOrDefault();
            }
        }
    }
}
