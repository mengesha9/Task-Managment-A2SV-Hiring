using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Tasks.Requests.Commands;
using MediatR;

namespace Application.Features.Tasks.Hanlders.Commands
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Unit>
    {
        public Task<Unit> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}