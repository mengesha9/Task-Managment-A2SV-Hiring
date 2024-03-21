using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entites
{
    public class Task:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }
        public int Priority { get; set; }
        public Labels Labels { get; set; }

        public string UserId { get; set; }
        public AppUser Users { get; set; }

        // Navigation property for project
        public int ProjectId { get; set; }
        public Project Projects { get; set; }
    }
}