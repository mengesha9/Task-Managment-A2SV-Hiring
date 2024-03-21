using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.DTOs.Tasks;
using Application.Features.Tasks.Requests.Queries;
using Application.Response;
using AutoMapper;
using MediatR;

namespace Application.Features.Tasks.Hanlders.Queries
{
   
    public class GetAllTaskInAProjectHandler : IRequestHandler<GetAllTasksInAProject, BaseCommandResponse<List<TaskReturnDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllTaskInAProjectHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<BaseCommandResponse<List<TaskReturnDto>>> Handle(GetAllTasksInAProject request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.TaskRepository.GetTasksInAProject(request.ProjectId);
            var mappedResult = _mapper.Map<List<TaskReturnDto>>(result);
            return new BaseCommandResponse<List<TaskReturnDto>>{
                Value=mappedResult,
                Success = true,
                Message = "Tasks retrieved successfully"
            };

        }
    }
}