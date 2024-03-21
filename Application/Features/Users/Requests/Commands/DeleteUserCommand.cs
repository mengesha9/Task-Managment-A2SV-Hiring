using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Response;
using MediatR;

namespace Application.Features.Users.Requests.Commands
{
    public class DeleteUserCommand:IRequest<BaseCommandResponse<Unit>>
    {
        public string Id { get; set; }
    }
}