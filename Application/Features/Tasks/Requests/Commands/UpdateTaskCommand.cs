using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Tasks;
using Application.Response;
using MediatR;

namespace Application.Features.Tasks.Requests.Commands
{
    public class UpdateTaskCommand: IRequest<Unit>
    {
        public int Id { get; set; }
        public TaskCreateDto TaskCreateDto { get; set; }
    }
}