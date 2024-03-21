using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entites
{
    public class AppUser:IdentityUser
    {

        public ICollection<Task> Tasks { get; set; }

        // Navigation property for projects
        public ICollection<UserProject> UserProjects { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
}