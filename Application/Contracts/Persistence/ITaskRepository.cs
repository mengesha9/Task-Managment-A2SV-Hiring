using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface ITaskRepository:IGenericRepository<Task>
    {
        Task<List<Domain.Entites.Task>> GetTasksInAProject(int projectId);
        Task<List<Domain.Entites.Task>> GetTasksForAUser(string userId);
        
    }
}