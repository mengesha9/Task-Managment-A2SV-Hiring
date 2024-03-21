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
    public class GetTasksByIdHandler : IRequestHandler<GetTaskByIdInAProject, BaseCommandResponse<TaskReturnDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetTasksByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<BaseCommandResponse<TaskReturnDto>> Handle(GetTaskByIdInAProject request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.TaskRepository.Get( request.TaskId);
            return new BaseCommandResponse<TaskReturnDto>{
                Value=_mapper.Map<TaskReturnDto>(result),
                Success = true,
                Message = "Task retrieved successfully"
            };

            }
        }
    }
