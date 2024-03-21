using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Tasks.Requests.Commands
{
    public class DeleteTaskCommand:IRequest<Unit>
    {
        public int Id { get; set; }
    
    }
}