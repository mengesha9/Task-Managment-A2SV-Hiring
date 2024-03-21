using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.DTOs.Users;
using Application.Features.Users.Requests.Queries;
using Application.Response;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Handlers.Queries
{
    public class GetUserByIdHandler : IRequestHandler<GetUserById, BaseCommandResponse<UserReturn>>
    {
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;
        public GetUserByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
      
        public Task<BaseCommandResponse<UserReturn>> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var user = _unitOfWork.UserRepository.GetUserById(request.Id);
            if (user == null)
            {
                return Task.FromResult(new BaseCommandResponse<UserReturn>
                {
                    Value = null,
                    Message = "User Not Found",
                    Success = false
                });
            }
            var response = _mapper.Map<UserReturn>(user);
            return Task.FromResult(new BaseCommandResponse<UserReturn>
            {
                Value = response,
                Message = "User Found",
                Success = true
            });
            
        }
    }
}