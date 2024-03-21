using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Tasks;
using Application.Response;
using MediatR;

namespace Application.Features.Tasks.Requests.Queries
{
    public class GetTaskByIdInAProject: IRequest<BaseCommandResponse<TaskReturnDto>>
    {
        public int TaskId { get; set; }
        
    }
}