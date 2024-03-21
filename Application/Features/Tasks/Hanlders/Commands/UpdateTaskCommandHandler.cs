using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.Tasks.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Tasks.Hanlders.Commands
{
    public class UpdateTaskCommandHandler:IRequestHandler<UpdateTaskCommand,Unit>
    {
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;
        public UpdateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<Task>(request.TaskCreateDto);
            await _unitOfWork.TaskRepository.Update(task);
            return Unit.Value;

        }
        
    }
    
}