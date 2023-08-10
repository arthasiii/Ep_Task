using EP_Task.Application.Dto;
using EP_Task.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EP_Task.Api.Formater
{
    public class CustomInputFormatter : TextInputFormatter
    {
        public CustomInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/plain"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }


        protected override bool CanReadType(Type type)
        {
            if (type == typeof(CustomEmployeeSalaryDto))
            {
                return base.CanReadType(type);
            }
            return false;
        }
        public async override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            var request = context.HttpContext.Request;

            using (var reader = new StreamReader(request.Body, encoding))
            {
                try
                {
                    string line;
                    var emp = new CustomEmployeeSalaryDto();
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        if (line.Contains("Line2:"))
                        {
                        var split = line.Substring(line.IndexOf("Line2:") + 5).Split(new char[] { '/' });

                        emp.FirstName = split[0].Trim().ToString();
                        emp.LastName = split[1].Trim().ToString();
                        emp.BasicSalary = Convert.ToDouble(split[2].Trim());
                        emp.Allowance = Convert.ToDouble(split[3].Trim());
                        emp.Transportation = Convert.ToDouble(split[4].Trim());
                        emp.DateSalary = split[5].Trim().ToString();

                      
                        }

                    }
                    return await InputFormatterResult.SuccessAsync(emp);
                }
                catch
                {
                    return await InputFormatterResult.FailureAsync();
                }
            }
        }
    }
}
