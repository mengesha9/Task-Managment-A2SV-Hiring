using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class UserProject
    {
      
            public int UserId { get; set; }
            public AppUser User { get; set; }

            public int ProjectId { get; set; }
            public Project Project { get; set; }
        

    }
}