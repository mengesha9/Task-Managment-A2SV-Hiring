using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DTOs.Tasks.Vallidators
{
    public class TaskCreateDtoValidators:AbstractValidator<TaskCreateDto>
    {
        
        public TaskCreateDtoValidators()
        {
            
        }
    }
}