using EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Command;
using EP_Task.Application.CQRS.EmployeeSalaryCommandQuery.Queries;
using EP_Task.Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EP_Task.Api.Controllers
{





    [ApiController]
    public class EmployeeSallaryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeSallaryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("{datatype}/EmployeeSallary/Add")]
        //[Route("/EmployeeSallary/Add")]
        public async Task<IActionResult> Add(string OverTimeCalculator,[FromBody] CustomEmployeeSalaryDto customEmployeeSalaryDto)
        {
            if(ModelState.IsValid)
            {

         var result= await _mediator.Send(new AddEmployeeSalaryCommand { OverTimeCalculator= OverTimeCalculator, Data = customEmployeeSalaryDto });
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpPut("{datatype}/EmployeeSallary/UpdateSalary")]
        public async Task<IActionResult> UpdateSalary(string OverTimeCalculator, [FromBody] CustomEmployeeSalaryDto customEmployeeSalaryDto)
        {
            if (ModelState.IsValid)
            {

                var result=  await _mediator.Send(new UpdateSalaryCommand { OverTimeCalculator = OverTimeCalculator, Data = customEmployeeSalaryDto });
                return Ok(result);
            }
            return BadRequest();
        }

        //get all for employee salaries
        [HttpDelete("EmployeeSallary/RemoveSalary")]
        public async Task<IActionResult> RemoveSalary([FromQuery] RemoveSalaryCommand RemoveSalaryCommand)
        {

            var result = await _mediator.Send(RemoveSalaryCommand);
            return Ok(result);

        }
        //get all for employee salaries
        [HttpGet("EmployeeSallary/Get")]
        public async Task<IActionResult> Get([FromQuery] GetsalaryQuery GetsalaryQuery)
        {

            var result = await _mediator.Send(GetsalaryQuery);
            return Ok(result);

        }

        //get all salary with time
        [HttpGet("EmployeeSallary/GetAllsalary")]
        public async Task<IActionResult> GetAllsalary([FromQuery] GetAllsalaryQuery GetAllsalaryQuery)
        {

            var result = await _mediator.Send(GetAllsalaryQuery);
            return Ok(result);

        }


        [HttpGet("EmployeeSallary/GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployee([FromQuery] GetAllEmployeeQuery GetAllEmployeeQuery)
        {

            var result = await _mediator.Send(GetAllEmployeeQuery);
            return Ok(result);

        }
    }
}
