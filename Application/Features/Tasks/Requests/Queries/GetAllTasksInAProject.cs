using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Tasks;
using Application.Response;
using MediatR;

namespace Application.Features.Tasks.Requests.Queries
{
    public class GetAllTasksInAProject: IRequest<BaseCommandResponse<List<TaskReturnDto>>>
    {
        public int ProjectId { get; set; }
        
    }
}