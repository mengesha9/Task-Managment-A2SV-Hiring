using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entites;

namespace Application.DTOs.Tasks
{
    public class TaskCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }
        public int Priority { get; set; }
        public Labels Labels { get; set; }

        public int UserId { get; set; }
        // Navigation property for project
        public int ProjectId { get; set; }
    
}
}