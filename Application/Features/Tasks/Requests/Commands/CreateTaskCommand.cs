using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Tasks;
using MediatR;

namespace Application.Features.Tasks.Requests.Commands
{
    public class CreateTaskCommand:IRequest<Unit>
    {
        public TaskCreateDto TaskCreateDto { get; set; }
        
    }
}