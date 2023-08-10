using EP_Task.Domain.Entities;
using EP_Task.Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Infrastructure.Infrastructurecontext
{
    public class EPTaskDbcontext:DbContext
    {

        public EPTaskDbcontext(DbContextOptions<EPTaskDbcontext> options):base(options)
        { }

        public DbSet<User> Users => Set<User>();
        public DbSet<UserRefreshToken> UserRefreshTokens => Set<UserRefreshToken>();
        public DbSet<Employee> Employees=> Set<Employee>();
        public DbSet<Salary> Salaries => Set<Salary>();  


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }

    }
}
