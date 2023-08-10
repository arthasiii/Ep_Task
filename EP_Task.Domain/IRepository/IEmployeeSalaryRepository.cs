using EP_Task.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Domain.IRepository
{
    public interface IEmployeeSalaryRepository
    {

        Task<List<Employee>> GetAllEmployeeAsync();

        Task<List<Salary>> GetAllSalarryAsync(int Id,string starttime,string endtime);

        Task<Salary> GetEmployeeSalary(int Id, string datetime);
    }
}
