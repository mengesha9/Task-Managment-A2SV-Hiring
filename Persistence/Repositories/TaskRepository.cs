using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class TaskRepository : GenericRepository<Task>, ITaskRepository
    {
        public readonly TaskManagmentDbContext _dbContext;
        public TaskRepository(TaskManagmentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Domain.Entites.Task>> GetTasksForAUser(string userId)
        {
            var result = await _dbContext.Tasks.Where(t => t.UserId == userId).ToListAsync(); 
            return result;
        }

        public async Task<List<Domain.Entites.Task>> GetTasksInAProject(int projectId)
        {
            var result = await _dbContext.Tasks.Where(t => t.ProjectId == projectId).ToListAsync();
            return result;
        }

    
    }
}