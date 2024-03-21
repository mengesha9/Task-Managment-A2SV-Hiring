using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entites
{
    public class Project:BaseEntity
    {
        public string Name {get;set;}
        public string Description {get;set;}
        public string Owner {get;set;}

        public ICollection<UserProject> UserProjects { get; set; }

        // Navigation property for tasks
        public ICollection<Task> Tasks { get; set; }
        public ICollection<AppUser> Users { get; set; }

    }
}