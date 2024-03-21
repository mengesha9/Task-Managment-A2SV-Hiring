using Application.DTOs.Users;
using Application.Response;
using MediatR;

namespace Application.Features.Users.Requests.Queries
{
    public class GetAllUsersQuerieRequest:IRequest<BaseCommandResponse<List<UserReturn>>>
    {
        

    }
}








