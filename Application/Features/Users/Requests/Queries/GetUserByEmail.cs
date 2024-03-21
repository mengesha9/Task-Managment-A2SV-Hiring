using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Users;
using Application.Response;
using MediatR;

namespace Application.Features.Users.Requests.Queries
{
    public class GetUserByEmail:IRequest<BaseCommandResponse<UserReturn>>
    {
        public string Email { get; set; }
    }
}