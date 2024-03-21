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
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmail, BaseCommandResponse<UserReturn>>
    {
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;
        public GetUserByEmailHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        public async Task<BaseCommandResponse<UserReturn>> Handle(GetUserByEmail request, CancellationToken cancellationToken)
        {
            var user =  await  _unitOfWork.UserRepository.GetUserByEmail(request.Email);
            if(user == null)
            {
                return new BaseCommandResponse<UserReturn>
                {
                    Value = null,
                    Message = "User Not Found",
                    Success = false
                };
            }
            var response = _mapper.Map<UserReturn>(user);
            return new BaseCommandResponse<UserReturn>
            {
                Value = response,
                Message = "User Found",
                Success = true
            };



        }
    }
}