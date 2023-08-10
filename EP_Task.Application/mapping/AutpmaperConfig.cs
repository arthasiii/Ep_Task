using AutoMapper;
using EP_Task.Application.Dto;
using EP_Task.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Application.mapping
{
    public class AutpmaperConfig:Profile
    {
        public AutpmaperConfig() {

            CreateMap<Employee, EmployeeDto>().ReverseMap();
        
        }

    }
}
