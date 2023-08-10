using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Task.Application.CQRS.AuthenticateComandQuery.Command
{


    public class RegisterCommand:IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {


        public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

        
        }
    }
}
