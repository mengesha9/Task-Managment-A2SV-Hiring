using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.DTOs.Users;
using Application.Features.Users.Requests.Queries;
using Application.Response;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Users.Handlers.Queries
{
    public class GetAllUsersQuerieHandler : IRequestHandler<GetAllUsersQuerieRequest, BaseCommandResponse<List<UserReturn>>>
    {
        public readonly IMapper _mapper;
        public readonly IUserRepository _userRepository;
        public GetAllUsersQuerieHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<List<UserReturn>>> Handle(GetAllUsersQuerieRequest request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAllUsers();
            var response = _mapper.Map<List<UserReturn>>(result);
            return new BaseCommandResponse<List<UserReturn>>{
                Value = response,
                Message = "All Users",
                Success = true
            };

        }
    }
}



